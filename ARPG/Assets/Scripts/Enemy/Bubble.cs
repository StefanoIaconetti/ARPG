using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public int speed = 4;

    public float lifetime;
    private float lifetimeSeconds;

    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    public void Update() {
        lifetimeSeconds -= Time.deltaTime;
        if(lifetimeSeconds <= 0) {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector2 direction) {
        rb.velocity = direction * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

}
