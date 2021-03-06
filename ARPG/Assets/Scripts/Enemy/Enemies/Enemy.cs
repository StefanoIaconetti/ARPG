﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walking,
    attacking,
    stagger
}

public class Enemy : MonoBehaviour {

    //variables
    public EnemyState currentState;
    public float health;
    public float maxHealth;
    public float speed;
    public float baseAttack;
    public float xpDrop;

    public LootTable drops;

    public Transform target;

    protected Animator animator;

    public Coroutine deathCoroutine;

    public void Start() {
        animator = GetComponent<Animator>();
    }

    private void Awake() {
        health = maxHealth;
    }

    //Function to take damage
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

    //Coroutine of DEATH!!!
    private IEnumerator DeathCo() {
        //make the animator play death animation
        animator.SetBool("IsDead", true);
        //Give the player xp and update his kill quests
        target.gameObject.GetComponent<Player>().GainXP(xpDrop);
        target.gameObject.GetComponent<Player>().UpdateKillQuests();
        //Drop an item
        DropItem();
        //Wait
        yield return new WaitForSeconds(1f);
        //Destroy the enemy
        Destroy(gameObject);
    }

    //Function to drop an item
    public void DropItem() {
        if (drops != null) {
            //Generate a random loot from loot table
            Item loot = drops.LootItem();
            if (loot != null) {
                //drop that item
                GameObject gameObject = Instantiate(Resources.Load(loot.name), transform.position, Quaternion.identity) as GameObject;
            }
        }
    }


}
