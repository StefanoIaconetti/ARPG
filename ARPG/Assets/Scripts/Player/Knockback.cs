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
                //Switch enemy state
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
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
                    Debug.Log("coroutine");

                }
            }
        }
    }

    //function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D enemy) {
        //if entity is not null initiate timer
        if (enemy != null) {
            Debug.Log("Entered courtine");
            //wait the knockback time
            yield return new WaitForSeconds(knockbackTime);                                             //THIS ISNT WORKING
            Debug.Log("Finished waiting");
            //set the entity back to its original state
            enemy.velocity = Vector2.zero;
            //Switch enemy state
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }
}
