using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the chest object
public class Chest : MonoBehaviour
{
	//Each chest has an array of inventory slots
	protected InventorySlot[] slots;

	//Checks to see if the chests inventory is open
	public bool inventoryOpen = false;

	//Each chest has an inventory
	public Inventory inventory;

	//Canvas for the chest
	public Canvas chestCanvas;

	//This holds the chestManager
	public ChestManager chestMang;

	//This holds the canvas of the playershop
	public Canvas playerShop;

	//This canvas holds the shopkeepers inventory
	public Canvas inventoryCanvas;

	//This is the list of items 
	public List<Item> chestItemManager = new List<Item>();

	//Inventory is created and slots are added
	public void Awake()
	{
		inventory = new Inventory();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	//When game starts
	void Start(){
		//canvas is false
		chestCanvas.enabled = false;

		//Inventory of the chest is added
		for (int i = 0; i < chestItemManager.Count; i++) {
			InventoryItem invItem = new InventoryItem (chestItemManager [i], 1);
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
		//If the inventory can open then call the chest close method
		if (chestMang.inventoryCanOpen) {

			ChestClose ();

		}
	}


	//Opens the chest
	public void ChestOpen(){
		//Enables the canvas 
		chestCanvas.enabled = true;

		//Updates the UI
		UpdateUI ();

		//Variable is set to true
		chestMang.inventoryCanOpen = true;

		//Game is paused
		Time.timeScale = 0;

	}

	//This method is called in the update, if the user pressed F then the inventory closes	
	public void ChestClose (){
		//If the inventory is opened and the player has pressed F
		if (chestMang.inventoryCanOpen && Input.GetKeyDown(KeyCode.F)) {

			//Canvas is now disabled
			chestMang.currentchest.chestCanvas.enabled = false;

			//Players inventory is true
			playerShop.enabled = true;

			//variable is set to false
			chestMang.inventoryCanOpen = false;

			//Game is unpaused
			Time.timeScale = 1;

		}
	}


}
