using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //This creates an instance of inventory
    public static Inventory instance;
    
    //In the awake method it checks to see if theres an instance of inventory, if there is a warning occurs. 
    //Unless another instance is made by accident in our code then the warning will never occur
    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance found");
            return;
        }
        instance = this;
    }

    //Creates a delegate OnItemChanged
    public delegate void OnItemChanged();
    public OnItemChanged itemChangeCallBack;

    //This is the amount of inventoy spaces
    public const int inventorySpace = 9;

    //This creates a list of items which will then become the inventory
    public List<Item> items = new List<Item>();

    //This method adds the item to the inventory
    public bool AddItem(Item item)
    {//If the items are greater than the amount of space then it returns false. Futher we will notify the user that they cannot have any more
        if(items.Count >= inventorySpace)
        {
            return false;
        }
        //Then adds the items
        items.Add(item);

        //If the callback is null then invoke
        if(itemChangeCallBack != null)
        {
            itemChangeCallBack.Invoke();
        }
        return true;
    }

    //This method is for removing items from the inventory
    public void RemoveItem (Item item)
    {
        //Removes item
        items.Remove(item);
        //If the callback is null then invoke
        if (itemChangeCallBack != null)
        {
            itemChangeCallBack.Invoke();
        }
    }
}
