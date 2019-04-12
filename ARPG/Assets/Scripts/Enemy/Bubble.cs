using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    //Variables
    public int speed = 4;

    public float lifetime;
    private float lifetimeSeconds;

    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    //Timer till it gets destroyed
    public void Update() {
        lifetimeSeconds -= Time.deltaTime;
        if(lifetimeSeconds <= 0) {
            Destroy(gameObject);
        }
    }

    //Shoots towards the target and continues even after reaching target
    public void Shoot(Vector2 direction) {
        rb.velocity = direction * speed;
    }

    //on trigger destroy it
    public void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

}
