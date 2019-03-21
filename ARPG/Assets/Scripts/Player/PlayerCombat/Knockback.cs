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

        //check if an entity is being hit
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) {
            //grab its rigidbody
            Rigidbody2D entity = collision.GetComponent<Rigidbody2D>();
            //if the enemy has a rigidbody then initiate knockback
            if (entity != null) {

                //Calculate the knockback
                Vector2 difference = entity.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log(difference.x + " " + difference.y);
                //add force to the enemy
                entity.AddForce(difference, ForceMode2D.Impulse);

                //If enemy...
                if (collision.gameObject.CompareTag("Enemy") && collision.isActiveAndEnabled && gameObject.tag != "Enemy") {
                    //Switch enemy state
                    entity.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    //initiate knockback coroutine
                    collision.GetComponent<Enemy>().Knock(entity, knockbackTime);
                    //make the enemy take damage
                    collision.GetComponent<Enemy>().TakeDamage(damage);
                }

                //If Player...
                if (collision.gameObject.CompareTag("Player") && collision.isActiveAndEnabled) {
                    Debug.Log("Check");
                    //change staggered state
                    entity.GetComponent<Player>().isStaggered = true;
                    //Knockback the player
                    collision.GetComponent<Player>().Knock(entity, knockbackTime);
                    //Have the player take damage
                    collision.GetComponent<Player>().TakeDamage(damage);
                }

            }
        }
    }


}
