using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//This game managers handles most of the things occuring in the game, there will only be one gamemanager
public class GameManager : MonoBehaviour
{
	//This holds the players inventory
    public Canvas inventory;

	//This holds the players equipment
	public Canvas inventoryEquipment;

	//This checks to see if the inventory is open
    public static bool inventoryOpen = false;

	//This holds the equipment manager, there will only be one
	public EquipmentManager equipManag;

	//This holds the player object so we can save
	public Player player;

	//This holds the save button so when this button is pressed the game saves
	public GameObject saveButton;

	//This will check if there is currently a loading gameobject, if there is load the recent save
	private GameObject checkLoad;

	//When the game starts
    void Start(){
		//Inventory is no longer active same with inventory equipment
		inventory.enabled = false;
		inventoryEquipment.enabled = false;

		//This populates the gameobject if it can find that they have loaded
		checkLoad = GameObject.Find ("LoadChecker");

		//If they did just load in
		if (checkLoad) {
			//This finds the file by using Application.data path then finds the file playerinfo.json
			var jsonContent = File.ReadAllText(Application.dataPath + "\\playerinfo.json");
			var playerData = JsonUtility.FromJson<SavingData>(jsonContent);

			//This now sets all the values to the corresponding variables
			Player.inventory = playerData.playerInventory;
			player.gold = playerData.currency;
			player.xp = playerData.experience;
			player.health = playerData.health;

			//Finds the player gameobject
			var playerVector = GameObject.Find ("Player");

			//Translates the gameobject to the last saved position
			playerVector.transform.Translate (playerData.playerPosition[0], playerData.playerPosition[1], playerData.playerPosition[2]);

			//Equipment that was worn last is now put back on the player
			equipManag.currentEquipment = playerData.equipableItems;

			//Both UI'S are updated so the player can see that their inventory and items are still there
			equipManag.UpdateUI ();
			Player.UpdateUI ();

			//Destroys the checkload
			Destroy (checkLoad);
		}


    }


    // Update is called once per frame
    void Update()
    {
        //This is with the inventory opening and closes
        if (Input.GetKeyDown(KeyCode.F))
        {
			//Either unpauses game or pauses game depending on the boolean statement
			//Game is paused and unpaused depending on if the inventory is active or not
			if (inventory.isActiveAndEnabled)
            {
                inventoryOpen = false;
				inventory.enabled = false;
				inventoryEquipment.enabled = false;
                Time.timeScale = 1;
            }
            else
            {
                inventoryOpen = true;
				inventory.enabled = true;
				inventoryEquipment.enabled = true;
                Time.timeScale = 0;
            }
        }

		//If the pause button is pressed (Esc) then the menu items are brought up
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (saveButton.activeSelf) {
				saveButton.SetActive (false);
			} else {
				saveButton.SetActive (true);

			}
		}
    }

	//When the player presses save
	public void OnSaveButton(){
		//This creates a object that holds all the data that needs to be saved
		SavingData savingData = new SavingData (player, equipManag);

		//This converts the object to a Json file
		var jsonData = JsonUtility.ToJson(savingData);

		//Creates a savepath (Where the file will actually save)
		var savePath = System.IO.Path.Combine(Application.dataPath, "playerinfo" + ".json");

		//Writes the json data to the savepath
		System.IO.File.WriteAllText(savePath, jsonData);

		//Lets us know if the file as been saved
		Debug.Log("Level saved to " + savePath);

	}

}
