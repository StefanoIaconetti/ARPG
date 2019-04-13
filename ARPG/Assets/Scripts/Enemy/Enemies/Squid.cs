using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : Enemy {

    //Variables
    public float chaseRange;
    public float attackRange;

    public GameObject bubblePrefab;
    public bool canFire = true;
    public float fireDelay;
    private float fireDelaySeconds;

    private Rigidbody2D rb;

    // Start is called before the first frame update
   public void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
    }

    //Timer between firing bubbles
    public void Update() {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <= 0) {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    // Update is called once per frame
    public void FixedUpdate() {
        CheckDistance();
    }

    //Check distance between player and squid
    public void CheckDistance() {
        if (target != null) {
            //If player is within chase range and outside of attack range
            if (Vector3.Distance(target.position, transform.position) <= chaseRange && Vector3.Distance(target.position, transform.position) > attackRange) {

                //Walk towards the player
                if (currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    ChangeAnimation(temp - transform.position);
                    rb.MovePosition(temp);
                    ChangeState(EnemyState.walking);
                    animator.SetBool("IsWalking", true);
                }
            } else {
                animator.SetBool("IsWalking", false);
            }

            //If within attack range
            if (Vector3.Distance(target.position, transform.position) <= attackRange) {
                if(canFire) {
                    ChangeState(EnemyState.attacking);
                    //Create a bubble
                    GameObject currentBubble = Instantiate(bubblePrefab, transform);
                    //Find direction
                    Vector3 temp = target.transform.position - transform.position;
                    //Shoot bubble
                    currentBubble.GetComponent<Bubble>().Shoot(temp);
                    canFire = false;
                }


            } else {
                ChangeState(EnemyState.idle);
            }
        }
    }

    private void SetAnimatorFloat(Vector2 setVector) {
        animator.SetFloat("x", setVector.x);
        animator.SetFloat("y", setVector.y);
    }

    //Change animation depending where the squid is facing
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

    //Changed enemy state
    private void ChangeState(EnemyState newState) {
        if (currentState != newState) {
            currentState = newState;
        }
    }


}
