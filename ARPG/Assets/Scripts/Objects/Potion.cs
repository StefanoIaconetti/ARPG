using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    public Equipable potion;
    public Player player;

    public Coroutine boostCo;

    private void Start() {
        Equipable potion = (Equipable)GetComponent<PickUp>().item;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void UsePotion(Equipable potion) {

        int tempStat = 0;

        switch (potion.name) {
            case "Health Potion":
                player.health += potion.statBoost;
                break;

            case "Magic Potion":
                player.wandDamage += potion.statBoost;
                break;

            case "Strength Potion":
                player.swordDamage += potion.statBoost;
                break;

            case "Protection Potion":
                player.protection += potion.statBoost;
                break;

            case "Speed Potion":
                tempStat = player.speed;
                player.speed *= potion.statBoost;
                break;

        }

        if(potion.name != "Health Potion" && boostCo == null) {
            Debug.Log("Waiting 30 seconds");
            boostCo = StartCoroutine(BoostCo(tempStat));
        }
    }

    public IEnumerator BoostCo(int tempStat) {
        yield return new WaitForSeconds(30f);
        switch (potion.name) {

            case "Magic Potion":
                player.wandDamage -= potion.statBoost;
                break;

            case "Strength Potion":
                player.swordDamage -= potion.statBoost;
                break;

            case "Protection Potion":
                player.protection -= potion.statBoost;
                break;

            case "Speed Potion":
                player.speed = tempStat;
                break;

        }

    }
}
