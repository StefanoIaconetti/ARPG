using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas inventory;
	public Canvas inventoryEquipment;

    public static bool inventoryOpen = false;

	public EquipmentManager equipManag;
	public Player player;

    void Start(){
		inventory.enabled = false;
		inventoryEquipment.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        //This is with the inventory opening and closes
        if (Input.GetKeyDown(KeyCode.F))
        {
			//Either unpauses game or pauses game depending on the boolean statement
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
    }

	public void OnSaveButton(){
		//SaveSystem.SavePlayerInfo (player, equipManag);



		SavingData data = new SavingData (player, equipManag);


		var levelDataToJson = JsonUtility.ToJson(data);
		var savePath = System.IO.Path.Combine(Application.dataPath, "playerinfo" + ".json");
		System.IO.File.WriteAllText(savePath, levelDataToJson);
		Debug.Log("Level saved to " + savePath);

	}


	public void OnLoadButton(){
		//SavingData data = SaveSystem.LoadPlayer ();

		//player.health = data.health;
		//player.xp = data.experience;
		//Player.inventory = data.playerInventory;
		//player.gold = data.currency;

		//var playerVector = GameObject.Find("Player").transform.position;

		//playerVector.x = data.playerPosition [0];
		//playerVector.y = data.playerPosition [1];
		//playerVector.z = data.playerPosition [2];


	}

}
