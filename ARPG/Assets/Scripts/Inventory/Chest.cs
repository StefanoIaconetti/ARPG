using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


	public static InventorySlot[] slots;
	public bool inventoryOpen = false;
	public static bool inventoryCanOpen = false;

	public static Inventory inventory;
	public Canvas chestCanvas;

	public static bool canOpen = false;

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
	public static void UpdateUI()
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

		if (inventoryCanOpen) {

			ShopClose ();

		}
	}



	public void ShopOpen(){
		chestCanvas.enabled = true;
		UpdateUI ();

		inventoryCanOpen = true;


		Time.timeScale = 0;

	}

	public void ShopClose (){

		if (inventoryCanOpen && Input.GetKeyDown(KeyCode.B)) {
			chestCanvas.enabled = false;

			inventoryCanOpen = false;

			Time.timeScale = 1;

		}
	}
}
