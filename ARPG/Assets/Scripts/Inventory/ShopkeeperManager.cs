using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperManager : MonoBehaviour
{
    
	public static InventorySlot[] slots;
	public bool inventoryOpen = false;

	public static Inventory inventory;
	public Canvas inventoryCanvas;

	public static bool canOpen = false;

	public List<Item> shopKeeperItemManager = new List<Item>();

	public void Awake()
	{
		inventory = new Inventory();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	void Start(){
		inventoryCanvas.enabled = false;

		for (int i = 0; i < shopKeeperItemManager.Count; i++) {
			InventoryItem invItem = new InventoryItem (shopKeeperItemManager [i], 1);
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
		if (canOpen) {
			inventoryCanvas.enabled = true;
			UpdateUI ();
			if(Input.GetKeyDown(KeyCode.B)){
				canOpen = false;
			}
		} else {
			inventoryCanvas.enabled = false;
		}
	}




}
