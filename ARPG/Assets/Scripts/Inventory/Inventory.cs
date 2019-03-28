using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//This creates an instance of inventory
	//public static Inventory instance;

	//public static Inventory shopKeepingInstance;

	//In the awake method it checks to see if theres an instance of inventory, if there is a warning occurs. 
	//Unless another instance is made by accident in our code then the warning will never occur

	void Awake(){
		//if(instance != null)
		//{
		//    Debug.LogWarning("More than one instance found");
		//    return;
		// }
		//  if (shopKeepingInstance != null)
		//{
		//  Debug.LogWarning("More than one instance found");
		//return;
		// }

		//shopKeepingInstance = this;
		//instance = this;
	}

	//Creates a delegate OnItemChanged
	public delegate void OnItemChanged();
	public OnItemChanged itemChangeCallBack;

	//This is the amount of inventoy spaces
	public const int inventorySpace = 9;

	//This creates a list of items which will then become the inventory
	public List<InventoryItem> items = new List<InventoryItem>();

	//This method adds the item to the inventory
	public bool AddItem(InventoryItem item)
	{//If the items are greater than the amount of space then it returns false. Futher we will notify the user that they cannot have any more
		if(items.Count >= inventorySpace)
		{
			return false;
		}

		//This checks to see if there are any items in the inventory, if there is not then it adds it to the inventory
		if (items.Count == 0)
		{
			items.Add(item);
			items[0].itemQuantity = 1;
		} else{
			//This goes through the current inventory
			int counter = 0;
			for (int i = 0; i < items.Count; i++)
			{
				//This counter increases every time the names are not the same


				counter++;
				//If the names are equal then the quantity increases
				if (items[i].item.name == item.item.name)
				{
					items[i].itemQuantity++;

					break;
				}

				//If there are no items that are the same then a new inventory slot is taken up
				if (counter == items.Count) { 
					items.Add(item);
					items[i + 1].itemQuantity = 1;
					break;
				}

			}
		}

		//If the callback is null then invoke
		if (itemChangeCallBack != null)
		{
			itemChangeCallBack.Invoke();
		}
		return true;
	}

	public void RemoveQuantity(Item item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			//If the names are equal then the quantity increases
			if (items[i].name == item.name)
			{
				items[i].itemQuantity--;

				break;
			}
		}

	}

	//This method is for removing items from the inventory
	public void RemoveItem (InventoryItem item)
	{
		//Removes item
		items.Remove(item);


		//If the callback is null then invoke
		//if (itemChangeCallBack != null)
		//{
		//  itemChangeCallBack.Invoke();
		//}
	}
}
