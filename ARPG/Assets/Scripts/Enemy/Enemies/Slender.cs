using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slender : Enemy {

    //Variables
    public float chaseRange;
    public float attackRange;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        CheckDistance();
    }

    //Check distance between enemy and player
    public void CheckDistance() {
        if (target != null) {
            //If the player is outside of the player attack range but still in its chase range
            if (Vector3.Distance(target.position, transform.position) <= chaseRange && Vector3.Distance(target.position, transform.position) > attackRange) {
                //if the enemy isnt staggered or is currently walking
                if (currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                    //Move towards the player
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    ChangeAnimation(temp - transform.position);
                    rb.MovePosition(temp);
                    ChangeState(EnemyState.walking);
                    animator.SetBool("IsWalking", true);
                } 
            } else {
                animator.SetBool("IsWalking", false);
            }

            //If the player is within attack range
            if(Vector3.Distance(target.position, transform.position) <= attackRange) {
                //Attack
                animator.SetBool("IsAttacking", true);
                ChangeState(EnemyState.attacking);
            } else {
                animator.SetBool("IsAttacking", false);
                ChangeState(EnemyState.idle);
            }
        }
    }


    private void SetAnimatorFloat(Vector2 setVector) {
        animator.SetFloat("x", setVector.x);
        animator.SetFloat("y", setVector.y);
    }

    //Function that will change the animation depending on what direction the enemy is facing
    private void ChangeAnimation(Vector2 direction) {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if (direction.x > 0) {
                SetAnimatorFloat(Vector2.right);
            } else if (direction.x < 0) {
                SetAnimatorFloat(Vector2.left);
            }
        } else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
            if (direction.y > 0) {
                SetAnimatorFloat(Vector2.up);
            } else if (direction.y < 0) {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    //Change the state of the enemy
    private void ChangeState(EnemyState newState) {
        if (currentState != newState) {
            currentState = newState;
        }
    }
}
