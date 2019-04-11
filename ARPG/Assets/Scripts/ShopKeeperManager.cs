using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds the current shopkeeper
public class ShopKeeperManager : MonoBehaviour{

	//This will helpw whenever we waant to figure out what the current shopkeeper is
	public ShopKeeperObject currentShopKeeper;

	//This checks to see if the inventory can open
	public bool inventoryCanOpen = false;

	//Checks the current shopkeeper then updates its UI
	public void CheckShopKeeper(){
		if (inventoryCanOpen) {
			currentShopKeeper.UpdateUI();
			currentShopKeeper.ShopOpen();
	}
}
}
