using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text levelText;
    public Text healthText;

    public Image xpBar;
    public Image healthBar;

    public Image potionImage;
    public Image defaultImage;

    public Player player;

    public Item[] items = new Item[5];


    private void Update() {
        levelText.text = "Lvl: " + player.level;
        healthBar.fillAmount = player.health / player.maxHealth;
        healthText.text = player.health + "/" + player.maxHealth;
        xpBar.fillAmount = player.xp / player.maxLevelXP;

        if (player.currentPotion != null) {
            potionImage.enabled = true;
            switch (player.currentPotion.name) {
                case "Health Potion":
                    potionImage.sprite = items[0].icon;
                    break;
                case "Strength Potion":
                    potionImage.sprite = items[1].icon;
                    break;
                case "Magic Potion":
                    potionImage.sprite = items[2].icon;
                    break;
                case "Protection Potion":
                    potionImage.sprite = items[3].icon;
                    break;
                case "Speed Potion":
                    potionImage.sprite = items[4].icon;
                    break;
            }
        } else {
            potionImage.enabled = false;
        }

    }

}
