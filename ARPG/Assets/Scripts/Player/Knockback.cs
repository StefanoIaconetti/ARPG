using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    //Variables
    public float thrust;
    public float knockbackTime;
    public float damage;

    //Function to utilize the knockback
    private void OnTriggerEnter2D(Collider2D collision) {
        //check if an enemy is being hit
        if (collision.gameObject.CompareTag("Enemy")) {
            //grab its rigidbody
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            //if the enemy has a rigidbody then initiate knockback
            if (enemy != null) {
                enemy.isKinematic = false;
                //Calculate the knockback
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                //add force to the enemy
                enemy.AddForce(difference, ForceMode2D.Impulse);
                //make the enemy take damage
                collision.GetComponent<Enemy>().TakeDamage(damage);
                //if the enemy is still alive then start the timer
                if (collision.GetComponent<Enemy>().isActiveAndEnabled) {
                    StartCoroutine(KnockCo(enemy));
                }
            }
        } else if (collision.gameObject.CompareTag("Player")) {
            //Grab the players ridgidbody
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            if (player != null) {
                player.isKinematic = false;
                //Calculate the knockback
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                //Add the force
                player.AddForce(difference, ForceMode2D.Impulse);
                //make the player take damage
                collision.GetComponent<Player>().TakeDamage(damage);
                //if the player is still alive start knockback timer
                if (collision.GetComponent<Player>().isActiveAndEnabled) {
                    StartCoroutine(KnockCo(player));
                }
            }
        }
    }

    //function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D entity) {
        //if entity is not null initiate timer
        if(entity != null) {
            //wait the knockback time
            yield return new WaitForSeconds(knockbackTime);
            //set the entity back to its original state
            entity.velocity = Vector2.zero;
            entity.isKinematic = true;
        }
    }
}
