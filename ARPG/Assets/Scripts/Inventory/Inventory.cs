using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//Everything that has a inventory will reference to this script, the user can Add and remove from their list of items
public class Inventory
{
	//This is the amount of inventoy spaces
	public const int inventorySpace = 9;

	//This creates a list of inventoryitems which will then become the inventory
	public List<InventoryItem> items = new List<InventoryItem>();

	//This method adds the item to the inventory
	public bool AddItem(InventoryItem item)
	{
		//If the items are greater than the amount of space then it returns false. Futher we will notify the user that they cannot have any more
		if(items.Count >= inventorySpace)
		{
			return false;
		}


		//If there are no items at all then add an item
		if (items.Count == 0) {
			items.Add (item);
			return true;
		} else {
			//This checks to see if there are any of the same items, if there are then the quantity increases instead of adding a new item 
			foreach (InventoryItem forItem in items) {
				if (forItem.item.name == item.item.name) {
					forItem.itemQuantity++;

					return true;
				}
			}
			//If there was no items that were the same then item is added to the inventory
			InventoryItem newItem = new InventoryItem(item.item, 1);
			items.Add (newItem);
		}

		return true;
	}

	//This method is for removing items from the inventory
	public bool RemoveItem (InventoryItem item)
	{
		//This iterates through the list of items
		for (int i = 0; i < items.Count; i++) {
			//If the names are the same
			if (items [i].item.name == item.item.name) {
				//If there are more than one then remove the item
				if (items[i].itemQuantity > 1) {
					//item.itemQuantity--;
					items [i].itemQuantity--;
					break;
				} else {
					//Otherwise remove at the index (If you do not remove at the index it can potentially find the item you are not attempting to look for)
					Debug.Log("comonnn");
					items.RemoveAt (i);
					break;

				}
			}
		}
		return true;
	}

}
