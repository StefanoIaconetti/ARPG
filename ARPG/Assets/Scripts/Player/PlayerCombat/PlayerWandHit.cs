using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWandHit : MonoBehaviour {

    public int damage;
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        damage = player.GetComponent<Player>().wandDamage;

        if (collision.CompareTag("Enemy")) {
             //If enemy is alive
            if (collision.isActiveAndEnabled) {
                //Make the enemy take damage
                collision.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
