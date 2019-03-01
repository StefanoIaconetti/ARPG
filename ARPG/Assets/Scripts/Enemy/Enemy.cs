using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public Transform target;
    public float chaseRange;

    public bool isTouchingTarget = false;

    // Start is called before the first frame update
    void Start() {
        //If there is a ridgidbody on the object then set it to the rb variable.
        if(this.GetComponent<Rigidbody2D>() != null) {
            rb = this.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update() {
        FollowTarget();
    }

    private void FollowTarget() { 
        //If the target is in range and isnt touching then chase after it
        if(target != null && isTouchingTarget == false) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isTouchingTarget = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isTouchingTarget = false;
    }
}
