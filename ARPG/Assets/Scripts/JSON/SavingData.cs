using System;
using UnityEngine;

[Serializable]
//This holds the data being saved
public class SavingData
{
	//Values that need to be saved
	public float[] playerPosition;
	public Inventory playerInventory;
	public Equipable[] equipableItems;
	public float currency;
	public float health;
	public float experience;
	public int playerLevel;
	public float maxHealth;
	public float playerMaxXp;

	//Sets all of data being saved
	public SavingData(Player player, EquipmentManager equipManag){

		playerInventory = Player.inventory;
		equipableItems = equipManag.currentEquipment;
		currency = player.gold;
		health = player.health;
		experience = player.xp;
		playerLevel = player.level;
		maxHealth = player.maxHealth;
		playerMaxXp = player.maxLevelXP;

		playerPosition = new float[3];
		playerPosition [0] = player.transform.position.x;
		playerPosition [1] = player.transform.position.y;
		playerPosition [2] = player.transform.position.z;

	}
}
