using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
	public Item item;
	public int itemQuantity;

	public InventoryItem(Item item, int itemQuantity){
		this.item = item;
		this.itemQuantity = itemQuantity;
	}


}
