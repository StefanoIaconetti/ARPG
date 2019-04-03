using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperManager : MonoBehaviour
{
	//public List<ShopKeeperObject> shopkeeperList = new List<ShopKeeperObject>();

	public ShopKeeperObject currentShopKeeper;

	//This checks to see if the inventory can open
	public bool inventoryCanOpen = false;


	public void CheckShopKeeper(){
		if (inventoryCanOpen) {
			//currentShopKeeper = shopkeeperList [currentShopKeeper.townNumber];
			currentShopKeeper.UpdateUI();
			currentShopKeeper.ShopOpen();
		//shopkeeperList [0].ShopOpen ();
	}

}

	public void bridge(){

	}
}
