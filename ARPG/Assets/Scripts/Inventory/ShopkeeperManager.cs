using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperManager : MonoBehaviour
{
    
	public static InventorySlot[] slots;
	public bool inventoryOpen = false;
	public static bool inventoryCanOpen = false;

	public static Inventory inventory;
	public Canvas inventoryCanvas;

	public static bool canOpen = false;

	public List<Item> shopKeeperItemManager = new List<Item>();



	public GameObject changePlayer;
	public GameObject changeShop;


	int minused;

	Vector3 originalPos;

	public Canvas playerShop;

	public void Awake()
	{
		inventory = new Inventory();
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
	public static void UpdateUI()
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

				//changePlayer.transform.position.Set (0, 0, 0);

			//canOpen = false;


			//inventoryVector.x =  -69.4f;



		if (minused == 1) {

			changePlayer.transform.position = originalPos;
			minused = 0;
		}


		changePlayer.transform.Translate (-251.7f, 0, 0);
		minused++;

		}

	public void ShopClose (){

		if (inventoryCanOpen && Input.GetKeyDown(KeyCode.B)) {
			inventoryCanvas.enabled = false;
			playerShop.enabled = false;
			changePlayer.transform.Translate (247.525f, 0, 0);
			//canOpen = false;

			inventoryCanOpen = false;

			Time.timeScale = 1;

		}
	}
}
