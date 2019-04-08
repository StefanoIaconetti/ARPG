using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walking,
    attacking,
    stagger
}

public class Enemy : MonoBehaviour {

    public EnemyState currentState;
    public float health;
    public float maxHealth;
    public float speed;
    public float baseAttack;
    public float xpDrop;

    public List<InventoryItem> drops;

    public Transform target;

    protected Animator animator;

    public Coroutine deathCoroutine;

    public void Start() {
        animator = GetComponent<Animator>();
    }

    private void Awake() {
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            if(deathCoroutine == null) {
                deathCoroutine = StartCoroutine(DeathCo());
            }
        }
    }

    //Function to knock the enemy back
    public void Knock(Rigidbody2D rb, float knockbackTime) {
        StartCoroutine(KnockCo(rb, knockbackTime));
    }

    //Function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D rb, float knockbackTime) {
        //If enemy is not null initiate timer
        if (rb != null) {
            //Wait the knockback time
            yield return new WaitForSeconds(knockbackTime);
            //Set the enemy back to its original state
            rb.velocity = Vector2.zero;
            //Switch enemy state
            rb.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }

    private IEnumerator DeathCo() {
        //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
        animator.SetBool("IsDead", true);
        target.gameObject.GetComponent<Player>().GainXP(xpDrop);
        target.gameObject.GetComponent<Player>().UpdateKillQuests();
        //DropItems();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Debug.Log("Enemy should die");
    }
    
    public void DropItems() {
        int numberOfItemsDrop = Random.Range(1, 4);
        for (int i = 0; i <= numberOfItemsDrop; i++) {
            int itemID = Random.Range(0, drops.Count);
            //Drop item
            //Instantiate(drops[itemID], transform, true);
        }
        
    }


}
