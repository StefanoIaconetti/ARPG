﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float thrust;
    public float knockbackTime;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null) {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy) {
        if(enemy != null) {
            yield return new WaitForSeconds(knockbackTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}
