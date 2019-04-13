using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//Inventory item holds the item and the quantity of the item
public class InventoryItem
{
	//Holds item
	public Item item;

	//Holds the current quantity
	public int itemQuantity;

	public InventoryItem(Item item, int itemQuantity){
		this.item = item;
		this.itemQuantity = itemQuantity;
	}


}
