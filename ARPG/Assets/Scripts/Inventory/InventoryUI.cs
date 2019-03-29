using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Parent items
   // public Transform itemsParent;

    //Arrays the inventory slots
    //InventorySlot[] slots;

    //Creates inventory
   // Inventory inventory;

    
   // void Start()
   // {
        //When the game starts an instance of inventory is created
       // inventory = Inventory.instance;

        //UI is then updated
       // inventory.itemChangeCallBack += UpdateUI;

        //Grabs whatsin the children
       // slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    //}//

    //Method that updates UI
   // void UpdateUI()
   // {   //Goes through the amount of slots are in the inventory
    //    for(int i = 0; i < slots.Length; i++)
     //   {//If i is less than the amount in the inventory
      //      if(i < inventory.items.Count)
       //     {//Adds the item
        //        slots[i].AddItem(inventory.items[i]);
        //    }
         //   else
         //   {
           //     //Clears the item
            //    slots[i].ClearSlot();
           // }
        //}
    //}
}
