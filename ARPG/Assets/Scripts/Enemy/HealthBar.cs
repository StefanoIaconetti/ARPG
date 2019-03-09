using System.Collections;
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
        enemy = GetComponent<Enemy>();
        healthBar = Instantiate(healthBarPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        healthBarFilled = new List<Image>(healthBar.GetComponentsInChildren<Image>()).Find(img => img != healthBar);
    }

    // Update is called once per frame
    void Update() {
        if (enemy.health > 0) {
            healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1f, 0));
            Debug.Log(enemy.health / enemy.maxHealth);
            healthBarFilled.fillAmount = enemy.health / enemy.maxHealth;
        } else {
            healthBar.gameObject.SetActive(false);
        }
    }
}
