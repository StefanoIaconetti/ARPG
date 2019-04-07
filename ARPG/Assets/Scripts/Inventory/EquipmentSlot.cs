using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EquipmentSlot : MonoBehaviour
{
	public EquipmentManager equipMang;

	//Creats an image name icon
	public Image icon;
	public int indexVal;
	public Button unequipButton;
	public Button itemButton;

	public Image defaultImage;

	//This adds an item to the inventory slot	
	public void AddItem (Equipable newItem)
	{
		icon.sprite = newItem.icon;
		icon.enabled = true;
		icon.color = Color.white;
		defaultImage.enabled = false;
	}

	//This clears the inventory slot
	public void ClearSlot() { 
		icon.sprite = null;
		icon.enabled = false;
		defaultImage.enabled = true;
	}


	public void OnUnEquipButton(){

		ClearSlot ();
		equipMang.Unequip (indexVal);


		unequipButton.gameObject.SetActive (false);


	}

	public void OnItemButton(){

		if (equipMang.currentEquipment [indexVal] != null) {
			if (unequipButton.gameObject.activeSelf) {
				unequipButton.gameObject.SetActive (false);
			} else {

				unequipButton.gameObject.SetActive (true);
			}
		}
	}




}
