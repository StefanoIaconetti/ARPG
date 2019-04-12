using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    idle,
    attacking
}

public class Boss : MonoBehaviour {

    public State currentState;
    public float health;
    public float maxHealth;
    public float baseAttack;
    public float xpDrop;
    public float attackRange;

    public bool canAttack;
    protected float timeSinceLastHit;
    public float waitTime;

    public Player player;
    public Transform playerTransform;

    protected Animator animator;

    public Coroutine deathCoroutine;

    public void Update() {
        timeSinceLastHit -= Time.deltaTime;
        if (timeSinceLastHit <= 0) {
            canAttack = true;
        }
    }

    public void Start() {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        CheckDistance();
    }

    public void CheckDistance() {
        if (playerTransform != null) {
            if (Vector3.Distance(playerTransform.position, transform.position) <= attackRange && canAttack) {
                animator.SetBool("IsAttacking", true);
                currentState = State.attacking;
                canAttack = false;
                timeSinceLastHit = waitTime;
            } else {
                animator.SetBool("IsAttacking", false);
                currentState = State.idle;
            }
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            if (deathCoroutine == null) {
                deathCoroutine = StartCoroutine(DeathCo());
            }
        }
    }

    private IEnumerator DeathCo() {
        //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
        animator.SetBool("IsDead", true);
        player.GainXP(xpDrop);
        player.UpdateKillQuests();
		//Call Final Function from boss manager
		BossManager bossManag = GameObject.Find("BossManager").GetComponent<BossManager>();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
		bossManag.Final ();
    }

}
