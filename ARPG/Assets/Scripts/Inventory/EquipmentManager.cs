using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manges the equipment
public class EquipmentManager : MonoBehaviour
{
	//This holds the equipment the player currently has
	public Equipable[] currentEquipment;

	//This holds the slot which the player will be able to see what they have equipped
	public EquipmentSlot[] equippedItems;

    protected Player player;
    protected Coroutine boostCo;

    //When the game starts
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		//Number of equipment slots are as long as the enum for equipable
		int numslots = System.Enum.GetNames (typeof(EquipType)).Length;

		//current equipment is the same size as the enum
		currentEquipment = new Equipable[numslots];
	}

	//Equip method
	public void Equip (Equipable newItem){
		//sets the slot index
		int slotIndex = (int)newItem.equipType;

		if (currentEquipment [slotIndex] != null) {
			InventoryItem pItem = new InventoryItem (currentEquipment [slotIndex], 1);
			Player.inventory.AddItem (pItem);
		} 
			equippedItems [slotIndex].indexVal = slotIndex;

		currentEquipment [slotIndex] = newItem;
			equippedItems [slotIndex].AddItem (newItem);


	}

	//If the unequip method is called
	public void Unequip (int indexNum){
		//Item is unequipped
		InventoryItem pItem = new InventoryItem (currentEquipment [indexNum], 1);

		//Readded to the inventory
		Player.inventory.AddItem (pItem);
		Player.UpdateUI ();
		currentEquipment [indexNum] = null;
	}


	//Method that updates UI
	public void UpdateUI() {
		//Equips the current equipment (Currently being used only for loading)
		for (int i = 0; i < currentEquipment.Length; i++)
		{
			if (currentEquipment[i] != null) {
				equippedItems[i].AddItem(currentEquipment[i]);
			}
		}
	}

    public void UsePotion(Equipable potion) {
        int tempStat = 0;

        switch (potion.name) {
            case "Health Potion":
                if(player.health == player.maxHealth) {
                    return;
                } else if (player.health + potion.statBoost > player.maxHealth) {
                    player.health = player.maxHealth;
                } else {
                    player.health += potion.statBoost;
                }
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

        if (potion.name != "Health Potion" && boostCo == null) {
            Debug.Log("Waiting 30 seconds");
            boostCo = StartCoroutine(BoostCo(tempStat, potion));
        }
    }

    public IEnumerator BoostCo(int tempStat, Equipable potion) {
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
