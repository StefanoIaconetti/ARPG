using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
	public Item item;
	public int itemQuantity;

	public InventoryItem(Item item, int itemQuantity){
		this.item = item;
		this.itemQuantity = itemQuantity;
	}


}
