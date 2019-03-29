using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InventorySlot : MonoBehaviour
{
	//Creats an image name icon
	public Image icon;

	//Button that removes items
	public Button itemButton;


	public Button optionsButton;
	public Text buttonText;

	public Text quantityText;

	private Animation anim;

	//Creats an item
	public InventoryItem item;



	//This adds an item to the inventory slot
	public void AddItem (InventoryItem newItem)
	{
		//Item is now the item grabbed
		item = newItem;
		//Debug.Log(item.name);
		//Changes the sprite and enables the icon. Then remove button can be used
		icon.sprite = item.item.icon;
		icon.enabled = true;

		quantityText.enabled = true;
		quantityText.text = item.itemQuantity + "";
	}

	//This clears the inventory slot
	public void ClearSlot() { 
		//Everything becomes null and unusable
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		quantityText.enabled = false;

	}

	//When the remove button is pressed then the specific item is removed
	public void OnOptionsShowButton()
	{
		Player.UpdateUI ();
		if (optionsButton.gameObject.activeSelf)
		{

			optionsButton.gameObject.SetActive(false);
		}
		else
		{
			//If there is an item present in the inventory then the player can sell
			if(item.item != null) {

				optionsButton.gameObject.SetActive(true);
			}
		} 
	}

	//When the player drops an item
	public void OnDropItemButton()
	{

		Debug.Log (item.item.name + "asdfasdf");
		//The options button now becomes false
		optionsButton.gameObject.SetActive(false);

		//Locates the location of player and allows the object appear infront of him
		var playerVector = GameObject.Find("Player").transform.position;

		//Changes the x or y depending on the direction
		switch (Player.directionString)
		{
		case "Up":
			playerVector.y += 4;
			break;

		case "Down":
			playerVector.y -= 4;
			break;

		case "Left":
			playerVector.x -= 4;
			break;

		case "Right":
			playerVector.x += 4;
			break;
		}



		//If there is more than 1 of the same item
		if (item.itemQuantity > 1)
		{
			
			//Calls the remove quantitty method
			Player.inventory.RemoveQuantity(item);

			//Text is changed
			quantityText.text = item.itemQuantity + "";

			//Object now appears right infront of the character
			GameObject gameObj = Instantiate(Resources.Load(item.item.name),
				playerVector,
				Quaternion.identity) as GameObject;
			Player.UpdateUI();

		}
		else
		{
			Debug.Log (item.item.name + "Whats working");
			//Item is removed from inventory
			Player.inventory.RemoveItem(item);


			//Object appears right infront of the character
			GameObject gameObj = Instantiate(Resources.Load(item.item.name),
				playerVector,
				Quaternion.identity) as GameObject;




			Player.UpdateUI();

		}



	}




	//Item is sold
	public void OnSellButton()
	{
		//Player.UpdateUI ();
		 
	}
}