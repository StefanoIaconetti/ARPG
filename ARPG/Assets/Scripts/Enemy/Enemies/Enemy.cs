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

    //Funtion that runs when an enemy gets defeated
    private IEnumerator DeathCo() {
        //Make the enemy play the death animation
        animator.SetBool("IsDead", true);
        //Give the player xp and update the players quests
        target.gameObject.GetComponent<Player>().GainXP(xpDrop);
        target.gameObject.GetComponent<Player>().UpdateKillQuests();
        //Enemy drops the loot
        DropLoot();
        //Wait a small amount of time
        yield return new WaitForSeconds(0.3f);
        //Destroy the gameobject
        Destroy(gameObject);
    }

    //Function to drop loot when enemy dies
    public void DropLoot() {
        if (drops.Count > 0) {
            //Generate a random amount of items that will drop 
            int numberOfItems = Random.Range(1, 4);

            //Loop through how many items will drop
            for (int i = 0; i < numberOfItems; i++) {
                //Generate a new item id
                int itemID = Random.Range(0, drops.Count);
                //Drop the item that corresponds with that id
                DropItem(drops[i]);
            }
        }
    }

    //Function to drop an item onto the ground at the monsters position
    public void DropItem(InventoryItem item) {
        //Instantiate a new item where the enemy is
        Instantiate(Resources.Load(item.item.name), transform.position, Quaternion.identity);

    }


}
