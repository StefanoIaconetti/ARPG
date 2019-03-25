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

        //Check if an enemy is being hit
        if (collision.gameObject.CompareTag("Enemy")) {
            //Grab its rigidbody
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            //If the enemy has a rigidbody then initiate knockback
            if (enemy != null) {

                //Calculate the knockback
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log(difference.x + " " + difference.y);
                //Add force to the enemy
                enemy.AddForce(difference, ForceMode2D.Impulse);

                //If enemy is alive
                if (collision.isActiveAndEnabled) {
                    //Switch enemy state
                    enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    //Initiate knockback coroutine
                    collision.GetComponent<Enemy>().Knock(enemy, knockbackTime);
                    //Make the enemy take damage
                    collision.GetComponent<Enemy>().TakeDamage(damage);
                }

            }
        }
    }


}
