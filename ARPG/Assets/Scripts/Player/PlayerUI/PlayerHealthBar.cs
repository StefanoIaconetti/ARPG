using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public Image health;
    public Player player;

    // Start is called before the first frame update
    void Start() {
        health = GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        health.fillAmount = player.health / player.maxHealth;

    }
}
