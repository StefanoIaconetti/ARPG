using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWandHit : MonoBehaviour {

    public int damage;
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //On trigger enter
    private void OnTriggerEnter2D(Collider2D collision) {

        //Find damage
        damage = player.GetComponent<Player>().wandDamage;

        //Check if its a boss or enemy
        if (collision.CompareTag("Enemy")) {
             //If enemy is alive
            if (collision.isActiveAndEnabled) {
                //Make the enemy take damage
                collision.GetComponent<Enemy>().TakeDamage(damage);
            }
        } else if (collision.gameObject.CompareTag("Boss")) {
            //If enemy is alive
            if (collision.isActiveAndEnabled) {
                //Make the enemy take damage
                collision.GetComponent<Boss>().TakeDamage(damage);
            }

        }
    }
}
