using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour{

	//This will helpw whenever we waant to figure out what the current shopkeeper is
	public Chest currentchest;

	//This checks to see if the inventory can open
	public bool inventoryCanOpen = false;

	//Checks the current shopkeeper then updates its UI
	public void CheckShopKeeper(){
		if (inventoryCanOpen) {
			currentchest.UpdateUI();
			currentchest.ChestOpen();

	}

}
}
