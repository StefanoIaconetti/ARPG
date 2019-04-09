using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : Enemy {

    public float chaseRange;
    public float attackRange;
    public Transform originalPosition;

    public GameObject bubblePrefab;
    public int shootSpeed;
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

    public void CheckDistance() {
        if (target != null) {
            if (Vector3.Distance(target.position, transform.position) <= chaseRange && Vector3.Distance(target.position, transform.position) > attackRange) {

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

            // Change to only shoot one at a time
            if (Vector3.Distance(target.position, transform.position) <= attackRange) {
                Debug.Log(canFire);
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

    private void ChangeState(EnemyState newState) {
        if (currentState != newState) {
            currentState = newState;
        }
    }


}
