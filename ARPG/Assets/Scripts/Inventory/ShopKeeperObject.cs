using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This manages the shopkeepers
public class ShopKeeperObject : MonoBehaviour
{
    //The inventory slot
	protected  InventorySlot[] slots;

	//If the inventory is open
	protected bool inventoryOpen = false;

	//Each shopkeeper has an inventory
	public Inventory inventory;

	//This canvas holds the shopkeepers inventory
	public Canvas inventoryCanvas;

	//This holds a list of items that a shop could have
	public List<Item> shopKeeperItemManager = new List<Item>(); 

	public int townNumber;

	//The change gameobjects allow me to change the position of the gameobject 
	public GameObject changePlayer;
	public GameObject changeShop;

	//This prevent the user from changing the position of the inventory
	int minused;

	//This is the original position of the gameobject and is instantiated when the game starts
	Vector3 originalPos;

	//This obtains the canvas of the players inventory
	public Canvas playerInventory;

	public ShopKeeperManager shopMang;

	//Creates an instance of inventory and fills in slots
	public void Awake()
	{
		inventory = new Inventory ();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	//Start method starts with the inventory canvas being false
	void Start(){
		inventoryCanvas.enabled = false;

		//Gathers the original position of the inventory
		originalPos = new Vector3(changePlayer.transform.position.x, changePlayer.transform.position.y, changePlayer.transform.position.z);

		//Loops and adds random items

		//TODO once items are implemented i can then add random items with random quantities, as of right now its just 2 items 
		for (int i = 0; i < shopKeeperItemManager.Count; i++) {
			InventoryItem invItem = new InventoryItem (shopKeeperItemManager [i], 1);
			inventory.AddItem (invItem);
		}
	}

	//Parent items
	public Transform itemsParent;

	//Method that updates UI
	public void UpdateUI()
	{   //Goes through the amount of slots are in the inventory

		for (int i = 0; i < slots.Length; i++)
		{//If i is less than the amount in the inventory
			if (i < inventory.items.Count)
			{//Adds the item
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				//Clears the item
				slots[i].ClearSlot();
			}
		}
	}



	// Update is called once per frame
	void Update()
	{
		//If the inventory is opnened the call the shopclose method
		if (shopMang.inventoryCanOpen) {
			ShopClose ();
		}

	}


	//Opens the shops menu
	public void ShopOpen(){
		//Enables the canvas
			inventoryCanvas.enabled = true;

		playerInventory.enabled = true;

		//Updates the UI
			UpdateUI ();

		//Inventory can open is now true, this then gives the ShopClose the ability to close
		shopMang.inventoryCanOpen = true;

		//Game is paused
		Time.timeScale = 0;

		//Counter measure just incase they press the same button multiple times
		if (minused == 1) {

			changePlayer.transform.position = originalPos;
			minused = 0;
		}

		//Translates the gameobject
		changePlayer.transform.Translate (-251.7f, 0, 0);
		minused++;

		}

	//This method is called in the update, if the user pressed F then the inventory closes	
	public void ShopClose (){
		if (shopMang.inventoryCanOpen && Input.GetKeyDown(KeyCode.F)) {

			//Closes the shop canvas
			shopMang.currentShopKeeper.inventoryCanvas.enabled = false;
			playerInventory.enabled = false;

			//Gives the gamemanager the ability to close the inventory
			//GameManager.inventoryOpen = false;

			//Translates the gameobject back
			changePlayer.transform.Translate (247.525f, 0, 0);

			//Resets by setting it to false
			shopMang.inventoryCanOpen = false;

			//Game is unpaused
			Time.timeScale = 1;
		}
	}
}
