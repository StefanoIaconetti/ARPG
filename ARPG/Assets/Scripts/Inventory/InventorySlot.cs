using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class InventorySlot : MonoBehaviour
{
	//Creats an image name icon
	public Image icon;

	//Button that when pressed displays the options button
	public Button itemButton;

	//This is the "sell" button, this button will only be in the players inventory
	public Button sellButton;
	//This button has many functions and will change depending on its onclick listener
	public Button optionsButton;

	public Button equipButton;

	//Text for the quantity of an item
	public Text quantityText;

	//Creats an item
	public InventoryItem item;

	//Accepts a player
	public Player player;

	public ShopKeeperManager shopMang;
	public ChestManager chestMang;
	public EquipmentManager equipMang; 

	public Equipable equipableItem;

	bool alreadyTrans = false;


	//This adds an item to the inventory slot	
	public void AddItem (InventoryItem newItem)
	{
		//If the item is an item that can be equiped, then it casts it 
		if (newItem.item.canEquip) {
			equipableItem = (Equipable)newItem.item;
		}

		//Item is now the item grabbed
		item = newItem;

		//Changes the sprite and enables the icon. Then remove button can be used
		icon.sprite = item.item.icon;
		icon.enabled = true;

		//The quantity of the item is displayed
		quantityText.enabled = true;
		quantityText.text = item.itemQuantity + "";
	}

	//This clears the inventory slot
	public void ClearSlot() { 
		//Everything becomes null and unusable
		item = null;
		equipableItem = null;
		icon.sprite = null;
		icon.enabled = false;
		quantityText.enabled = false;

	}

	//When the Options button is pressed
	public void OnOptionsShowButton()
	{

		if (alreadyTrans == true) {
			
			equipButton.gameObject.SetActive (false);
			optionsButton.transform.Translate (0, -10f, 0);
			optionsButton.gameObject.SetActive (false);
			alreadyTrans = false;
		}

		if (equipableItem != null && alreadyTrans == false) {
			equipButton.gameObject.SetActive (true);
			optionsButton.transform.Translate (0, 10, 0);
			optionsButton.gameObject.SetActive (true);
			alreadyTrans = true;
		} else {
			if (shopMang != null && shopMang.inventoryCanOpen && sellButton != null) {
				sellButton.gameObject.SetActive (true);
			} else {
				if (sellButton != null) {
					sellButton.gameObject.SetActive (false);
				}

				if (optionsButton.gameObject.activeSelf) {
					optionsButton.gameObject.SetActive (false);
				} else {
					//If there is an item present in the inventory then the player can sell
					if (item.item != null) {
						optionsButton.gameObject.SetActive (true);
					}

				}
			}
		}
	}


	//When the player drops an item
	public void OnDropItemButton()
	{
		//The options button now becomes false
		optionsButton.gameObject.SetActive(false);
		equipButton.gameObject.SetActive (false);

		//Locates the location of player and allows the object appear infront of him
		var playerVector = GameObject.Find("Player").transform.position;

		//Changes the x or y depending on the direction
		switch (Player.directionString)
		{
		case "Up":
			playerVector.y += 4;
			break;

		case "Down":
			playerVector.y -= 4;
			break;

		case "Left":
			playerVector.x -= 4;
			break;

		case "Right":
			playerVector.x += 4;
			break;
		}

		//If there is more than 1 of the same item
		//if (item.itemQuantity > 1)
		//{
			
			//Calls the remove quantitty method
			//Player.inventory.RemoveQuantity(item);

			//Text is changed
			//quantityText.text = item.itemQuantity + "";

			//Object now appears right infront of the character
		//	GameObject gameObj = Instantiate(Resources.Load(item.item.name),
			//	playerVector,
			////	Quaternion.identity) as GameObject;
		//	Player.UpdateUI();

		//}
		//else
		//{
			//Item is removed from inventory
			Player.inventory.RemoveItem(item);


			//Object appears right infront of the character
			GameObject gameObj = Instantiate(Resources.Load(item.item.name),
				playerVector,
				Quaternion.identity) as GameObject;

		//If you for any reason get an error that it cant find it or whater
		//Then that means this name is different than the prefab name


			Player.UpdateUI();

		//}



	}

	public void OnSellButton(){

		player.gold += item.item.cost;


		Player.inventory.RemoveItem (item);

		shopMang.currentShopKeeper.inventory.AddItem (item);

		Player.UpdateUI ();
		shopMang.currentShopKeeper.UpdateUI ();
	}


	//Item is sold
	public void OnBuyButton()
	{
		if (player.gold - item.item.cost >= 0) {

				
			player.gold -= item.item.cost;

			//if (item.itemQuantity > 1) {
				//ShopkeeperManager.inventory.RemoveQuantity (item);
			//} else {


			shopMang.currentShopKeeper.inventory.RemoveItem (item);
			//}


			Player.inventory.AddItem(item);

			Player.UpdateUI ();
			shopMang.currentShopKeeper.UpdateUI ();
		}
	}




	public void OnGrabButton(){

		//if (item.itemQuantity > 1) {

			//Chest.inventory.RemoveQuantity (item);
		//} else {

		chestMang.currentchest.inventory.RemoveItem (item);
		Player.inventory.AddItem (item);

		//}

		Player.UpdateUI ();
		chestMang.currentchest.UpdateUI ();
	}


	public void OnEquipButton(){
		//The options button now becomes false
		optionsButton.gameObject.SetActive(false);
		equipButton.gameObject.SetActive (false);

		equipMang.Equip (equipableItem);
		Player.inventory.RemoveItem (item);
		Player.UpdateUI();

	}
}