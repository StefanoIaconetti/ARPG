using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text levelText;
    public Text healthText;

    public Image xpBar;
    public Image healthBar;

    public Image hotbarClose;
    public Image hotbarRanged;
    public Image hotbarPotion;

    public Player player;


    private void Update() {
        levelText.text = "Lvl: " + player.level;
        healthBar.fillAmount = player.health / player.maxHealth;
        healthText.text = player.health + "/" + player.maxHealth;
        xpBar.fillAmount = player.xp / player.maxLevelXP;

        //hotbarClose.fillAmount = 
    }

}
