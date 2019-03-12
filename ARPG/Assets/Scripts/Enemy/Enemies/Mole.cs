using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy {

    public float chaseRange;
    public float attackRange;
    public Transform originalPosition;

    private Rigidbody2D rb;
    protected Animator animator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = EnemyState.idle;
    }

    // Update is called once per frame
    void FixedUpdate() {
        CheckDistance();
    }

    public void CheckDistance() {
        if (target != null) {
            if (Vector3.Distance(target.position, transform.position) <= chaseRange && Vector3.Distance(target.position, transform.position) > attackRange) {

                if (currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    rb.MovePosition(temp);
                    ChangeState(EnemyState.walking);
                }
            }
        }
    }

    private void ChangeState(EnemyState newState) {
        if(currentState != newState) {
            currentState = newState;
        }
    }
}
