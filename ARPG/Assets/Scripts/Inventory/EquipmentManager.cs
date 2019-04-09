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

	//When the game starts
	void Start(){
		//Number of equipment slots are as long as the enum for equipable
		int numslots = System.Enum.GetNames (typeof(EquipType)).Length;

		//current equipment is the same size as the enum
		currentEquipment = new Equipable[numslots];
	}

	//Equip method
	public void Equip (Equipable newItem){
		//sets the slot index
		int slotIndex = (int)newItem.equipType;

		//Adds the item
		equippedItems [slotIndex].AddItem(newItem);
		equippedItems [slotIndex].indexVal = slotIndex;
		currentEquipment [slotIndex] = newItem;
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
				Equip (currentEquipment [i]);
			}
		}
	}
}
