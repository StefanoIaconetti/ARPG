using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walking,
    attacking,
    stagger
}

public class Enemy : MonoBehaviour {

    public EnemyState currentState;
    public float health;
    public float maxHealth;
    public float speed;
    public float baseAttack;

    public Transform target;
    //protected Vector2 direction;

    // Start is called before the first frame update
    void Start() {

    }

    private void Awake() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
            this.gameObject.SetActive(false);
        }
    }


}
