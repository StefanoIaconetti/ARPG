using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This manages the shopkeepers
public class ShopkeeperObject : MonoBehaviour
{
    //The inventory slot
	protected  InventorySlot[] slots;

	//If the inventory is open
	protected bool inventoryOpen = false;

	//This checks to see if the inventory can open
	public  bool inventoryCanOpen = false;

	//Each shopkeeper has an inventory
	public Inventory inventory;

	//This canvas holds the players inventory
	public Canvas inventoryCanvas;

	//Static bool that changes depending on conditions
	//public static bool canOpen = false;

	//This holds a list of items that a shop could have
	public List<Item> shopKeeperItemManager = new List<Item>();


	//The change gameobjects allow me to change the position of the gameobject 
	public GameObject changePlayer;
	public GameObject changeShop;


	int minused;

	Vector3 originalPos;

	public Canvas playerShop;

	public void Awake()
	{
		inventory = new Inventory ();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	void Start(){
		inventoryCanvas.enabled = false;
		originalPos = new Vector3(changePlayer.transform.position.x, changePlayer.transform.position.y, changePlayer.transform.position.z);


		for (int i = 0; i < shopKeeperItemManager.Count; i++) {
			InventoryItem invItem = new InventoryItem (shopKeeperItemManager [i], 1);
			inventory.AddItem (invItem);
		}
	}

	//Parent items
	public Transform itemsParent;

	//Method that updates UI
	public  void UpdateUI()
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

		if (inventoryCanOpen) {

			ShopClose ();

		}
	}



	public void ShopOpen(){
			inventoryCanvas.enabled = true;
			playerShop.enabled = true;
			UpdateUI ();

		inventoryCanOpen = true;


		Time.timeScale = 0;

		if (minused == 1) {

			changePlayer.transform.position = originalPos;
			minused = 0;
		}


		changePlayer.transform.Translate (-251.7f, 0, 0);
		minused++;

		}

	public void ShopClose (){

		if (inventoryCanOpen && Input.GetKeyDown(KeyCode.F)) {
			inventoryCanvas.enabled = false;
			GameManager.inventoryOpen = true;
			//playerShop.enabled = false;
			changePlayer.transform.Translate (247.525f, 0, 0);
			//canOpen = false;

			inventoryCanOpen = false;

			Time.timeScale = 1;

		}
	}
}
