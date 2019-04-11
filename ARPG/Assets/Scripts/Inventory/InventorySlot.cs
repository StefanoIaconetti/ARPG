using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

//This will hold everything to do with the item slot in the players inventory
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

	//If the button is equipable 
	public Button equipButton;

	//Text for the quantity of an item
	public Text quantityText;

	//This will hold a item so it is accessible throughout this script
	public InventoryItem item;

	//Accepts a player
	 Player player;

	ShopKeeperManager shopMang;
	ChestManager chestMang;
	EquipmentManager equipMang;
	//Creates a public equipable item, if the item is equipable then this is populated
	Equipable equipableItem;

	//boolean that checks if the optionsbutton has already translated
	bool alreadyTrans = false;


	public void Start(){
		//This accepts all the managers

		player = GameObject.Find("Player").GetComponent<Player>();
		 shopMang = GameObject.Find("ShopKeeperManager").GetComponent<ShopKeeperManager>();
		 chestMang = GameObject.Find("ChestManager").GetComponent<ChestManager>();
		 equipMang = GameObject.Find("EquipmentManager").GetComponent<EquipmentManager>(); 
	}


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

		//If there is no item then null is displayed
		if (item == null) {
			Debug.Log ("Null");
		}else{
			EnableDisable ();
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
			//Item is removed from inventory
			Player.inventory.RemoveItem(item);


			//Object appears right infront of the character
			GameObject gameObj = Instantiate(Resources.Load(item.item.name),
				playerVector,
				Quaternion.identity) as GameObject;

		//UI is updated
			Player.UpdateUI();
	}

	//If the player is in a shop and sells that item
	public void OnSellButton(){

		//Gold is increased
		player.gold += item.item.cost;

		//Item is removed from inventory
		Player.inventory.RemoveItem (item);

		//Item is added to the shopkeepers inventory
		shopMang.currentShopKeeper.inventory.AddItem (item);

		//Both UI's are updated
		Player.UpdateUI ();
		shopMang.currentShopKeeper.UpdateUI ();
	}


	//If the player presses the buy button from the shopkeeper
	public void OnBuyButton()
	{
		//If the player has the money
		if (player.gold - item.item.cost >= 0) {
			
			//The players gold is reduced
			player.gold -= item.item.cost;

			//Item is removed from the shopkeeper
			shopMang.currentShopKeeper.inventory.RemoveItem (item);

			//Item is added to the players inventory
			Player.inventory.AddItem (item);

			//Both UI's are updated
			Player.UpdateUI ();
			shopMang.currentShopKeeper.UpdateUI ();
		} else {
			Debug.Log ("Not enough money");
		}
	}



	//This is specifically for chests
	public void OnGrabButton(){
		//Item is removed from the chests
		chestMang.currentchest.inventory.RemoveItem (item);

		//Item is added to the players
		Player.inventory.AddItem (item);

		//UI's are updated
		Player.UpdateUI ();
		chestMang.currentchest.UpdateUI ();
	}

	//If the item is equipable the button holding this onclick will be called
	public void OnEquipButton(){

		//The options button and equip button now becomes false
		optionsButton.gameObject.SetActive(false);
		equipButton.gameObject.SetActive (false);

		//The equipable is equipped
		equipMang.Equip (equipableItem);

		//Item is removed from inventory
		Player.inventory.RemoveItem (item);

		//UI is updated
		Player.UpdateUI();

	}





	public void EnableDisable(){
		//If the options button has already been translated then it returns it to normal
		if (alreadyTrans == true) {
			equipButton.gameObject.SetActive (false);
			optionsButton.transform.Translate (0, -10f, 0);
			optionsButton.gameObject.SetActive (false);
			alreadyTrans = false;
		}else if (equipableItem != null && alreadyTrans == false && shopMang.inventoryCanOpen == false) {
			equipButton.gameObject.SetActive (true);
			optionsButton.transform.Translate (0, 10, 0);
			optionsButton.gameObject.SetActive (true);
			alreadyTrans = true;
		} else {
			//If the shopmanager can open
			if (shopMang != null && shopMang.inventoryCanOpen && sellButton != null) {
				sellButton.gameObject.SetActive (true);
			} else {
				//If the sell button is not null then make it false
				if (sellButton != null) {
					sellButton.gameObject.SetActive (false);
				}
				//If the options button is active then set it false
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
}