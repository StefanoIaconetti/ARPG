using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour {

    //Variables
    public float thrust;
    public float knockbackTime;
    public float damage;

    private void Start() {
        try {
            damage = gameObject.GetComponentInParent<Enemy>().baseAttack;
        } catch {
            damage = gameObject.GetComponentInParent<Boss>().baseAttack;
        }
    }

    //Function to utilize the knockback
    private void OnTriggerEnter2D(Collider2D collision) {

        //Check if the player is being hit
        if (collision.gameObject.CompareTag("Player")) {
            //Grab its rigidbody
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            //If the enemy has a rigidbody then initiate knockback
            if (player != null && !collision.GetComponent<Player>().isStaggered) {

                //Calculate the knockback
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                //Debug.Log(difference.x + " " + difference.y);
                //Add force to the player
                player.AddForce(difference, ForceMode2D.Impulse);

                //If player isn't dead
                if (collision.isActiveAndEnabled) {
                    Debug.Log("Enemy hit the player");
                    //Change staggered state
                    player.GetComponent<Player>().isStaggered = true;
                    //Knockback the player
                    collision.GetComponent<Player>().Knock(player, knockbackTime);
                    //Have the player take damage
                    collision.GetComponent<Player>().TakeDamage(damage);
                }

            }
        }
    }
}
