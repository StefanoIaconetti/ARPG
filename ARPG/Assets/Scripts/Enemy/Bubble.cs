using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public int speed = 4;
    public Transform target;

    public void OnEnable() {
        target = GameObject.FindWithTag("Player").transform;
    }

    public void Update() {
        GetComponent<Rigidbody2D>().velocity = (target.transform.position - transform.position).normalized * speed; 
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

}
