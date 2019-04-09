using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

//This holds the equipment slot
public class EquipmentSlot : MonoBehaviour
{
	//Holds an equipment manager
	public EquipmentManager equipMang;

	//Holds the image
	public Image icon;

	//Indexval is so the equipmentmanager knows what inventory item this is
	public int indexVal;

	//Holds the unequip button
	public Button unequipButton;

	//Holds the item button
	public Button itemButton;

	//Holds the default image
	public Image defaultImage;

	//Holds an equipable item
	Equipable item;

	//This adds an item to the inventory slot	
	public void AddItem (Equipable newItem)
	{
		//If an item is added all these values are changed
		item = newItem;
		icon.sprite = newItem.icon;
		icon.enabled = true;
		icon.color = Color.white;
		defaultImage.enabled = false;
	}

	//This clears the inventory slot
	public void ClearSlot() { 
		//If the slot is cleared then everything is null
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		defaultImage.enabled = true;
	}

	//When the unequip button is pressed
	public void OnUnEquipButton(){
		//Slot is cleared
		ClearSlot ();

		//Unequip method is called
		equipMang.Unequip (indexVal);

		//Button is set to false
		unequipButton.gameObject.SetActive (false);
	}

	//If the item button is pressed
	public void OnItemButton(){
		//If nothing is in the inventory slot
		if (item == null) {
			Debug.Log ("Null");
		}else{
			//If the indeval is not null
			if (equipMang.currentEquipment [indexVal] != null) {
				//Button is false
				if (unequipButton.gameObject.activeSelf) {
					unequipButton.gameObject.SetActive (false);
				} else {
					//Button is true
					unequipButton.gameObject.SetActive (true);
				}
			}
		}
	}
}
