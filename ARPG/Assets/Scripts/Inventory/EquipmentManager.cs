using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	public Equipable[] currentEquipment;
	public EquipmentSlot[] equippedItems;

	void Start(){
		int numslots = System.Enum.GetNames (typeof(EquipType)).Length;
		Debug.Log (numslots);
		currentEquipment = new Equipable[numslots];
	}

	public void Equip (Equipable newItem){
		int slotIndex = (int)newItem.equipType;

		equippedItems [slotIndex].AddItem(newItem);
		equippedItems [slotIndex].indexVal = slotIndex;
		currentEquipment [slotIndex] = newItem;
	}


	public void Unequip (int indexNum){
		InventoryItem pItem = new InventoryItem (currentEquipment [indexNum], 1);
		Player.inventory.AddItem (pItem);
		Player.UpdateUI ();
		currentEquipment [indexNum] = null;
	}


	//Method that updates UI
	public void UpdateUI() {

		//UPDATE GATHER QUESTS HERE

		//Goes through the amount of slots are in the inventory

		for (int i = 0; i < currentEquipment.Length; i++)
		{
			if (currentEquipment[i] != null) {
				Equip (currentEquipment [i]);
			}
		}
	}
}
