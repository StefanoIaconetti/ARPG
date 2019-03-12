using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //Creats an image name icon
    public Image icon;

    //Button that removes items
    public Button removeButton;

    public Text quantityText; 

    //Creats an item
    Item item;

    //This adds an item to the inventory slot
    public void AddItem (Item newItem)
    {
        //Item is now the item grabbed
        item = newItem;
        //Changes the sprite and enables the icon. Then remove button can be used
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        quantityText.enabled = true;
        quantityText.text = item.quantity + "";
    }

    //This clears the inventory slot
    public void ClearSlot() { 
        //Everything becomes null and unusable
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        quantityText.enabled = false;
    }
    //When the remove button is pressed then the specific item is removed
    public void OnRemoveButton()
    {
        Inventory.instance.RemoveItem(item);
    }
}
