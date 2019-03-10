using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;
    public float maxHealth;

    public Rigidbody2D rb;
    public float speed;
    public Transform target;
    public float chaseRange;
    protected Vector2 direction;

    public bool isTouchingTarget = false;

    protected Animator animator;

    protected bool IsAttacking = false;

    public bool IsMoving {
        get {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected Coroutine attackCoroutine;

    // Start is called before the first frame update
    void Start() {
        //Set the rigidbody.
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        MoveChar();
    }

    //Moves a character
    public void MoveChar() {
        rb.velocity = direction.normalized * speed;
    }

    private void Awake() {
        health = maxHealth;
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

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
            this.gameObject.SetActive(false);
        }
    }

    public void HandleLayers() {
        if (IsMoving) {
            ActivateLayer("Walk");
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
        } else {
            ActivateLayer("Idle");
        }
    }

    public void ActivateLayer(string layerName) {
        for (int i = 0; i < animator.layerCount; i++) {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }


}
