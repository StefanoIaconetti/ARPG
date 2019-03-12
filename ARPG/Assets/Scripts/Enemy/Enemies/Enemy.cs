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

    public EnemyState currentState;
    public float health;
    public float maxHealth;
    public float speed;
    public float baseAttack;

    public Transform target;

    private void Awake() {
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rb, float knockbackTime) {
        StartCoroutine(KnockCo(rb, knockbackTime));
    }

    //function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D rb, float knockbackTime) {
        //if entity is not null initiate timer
        if (rb != null) {
            //wait the knockback time
            yield return new WaitForSeconds(knockbackTime);
            //set the entity back to its original state
            rb.velocity = Vector2.zero;
            //Switch enemy state
            rb.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }


}