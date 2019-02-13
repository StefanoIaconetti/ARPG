using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D rb;
    public GameObject target;

    // Start is called before the first frame update
    void Start() {
        //If there is a ridgidbody on the object then set it to the rb variable.
        if(this.GetComponent<Rigidbody2D>() != null) {
            rb = this.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    //Runs every frame
    void FixedUpdate() {
        //If the player is close to the enemy then start tracking player
        //if(target.transform.position )

    }


    void OnTriggerEnter2D(Collider2D other) {
        //if the enemy gets close enough make the enemy attack the player

        //if the player is hit with an attack initiate knockback
    }
}
