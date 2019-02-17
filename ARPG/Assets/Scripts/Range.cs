using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    private Enemy parent;

    private void Start() {
        //get enemy object
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //if the player is within range then set the target
        if (collision.tag == "Player") {
            parent.target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //if the player is outside of the range then reset the target to nothing
        if (collision.tag == "Player") {
            parent.target = null;
        }
    }
}
