using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public ChestManager chestMang;
	public Canvas playerShop;

	public List<Item> chestItemManager = new List<Item>();

	public void Awake()
	{
		inventory = new Inventory();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	void Start(){
		chestCanvas.enabled = false;


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
		if (chestMang.inventoryCanOpen) {

			ChestClose ();

		}
	}



	public void ChestOpen(){
		chestCanvas.enabled = true;
		UpdateUI ();

		chestMang.inventoryCanOpen = true;


		Time.timeScale = 0;

	}


	//This method is called in the update, if the user pressed F then the inventory closes	
	public void ChestClose (){
		if (chestMang.inventoryCanOpen && Input.GetKeyDown(KeyCode.F)) {
			
			chestMang.currentchest.chestCanvas.enabled = false;
			playerShop.enabled = true;

			chestMang.inventoryCanOpen = false;

			Time.timeScale = 1;

		}
	}


}
