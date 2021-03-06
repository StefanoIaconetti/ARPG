﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject healthBarPrefab;
    public Enemy enemy;
    protected Image healthBar;
    protected Image healthBarFilled;

    // Start is called before the first frame update
    void Start() {
        //Create a health bar on the enemy game object
        enemy = GetComponent<Enemy>();
        healthBar = Instantiate(healthBarPrefab, GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<Canvas>().transform).GetComponent<Image>();
        healthBarFilled = new List<Image>(healthBar.GetComponentsInChildren<Image>()).Find(img => img != healthBar);
    }

    // Update is called once per frame
    void Update() {
        //update the healthbar
        if (enemy.health > 0) {
			if (healthBar != null) {
				healthBar.transform.position = Camera.main.WorldToScreenPoint (transform.position + new Vector3 (0, 1f, 0));
				healthBarFilled.fillAmount = enemy.health / enemy.maxHealth;
			}
		} else {
			if (healthBar != null) {
            healthBar.gameObject.SetActive(false);
            //Destroy(healthBar);
			}
        }
    }
}
