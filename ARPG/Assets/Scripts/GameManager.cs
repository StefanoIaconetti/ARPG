using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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


		var levelFileJsonContent = File.ReadAllText(Application.dataPath + "\\playerinfo.json");
		var levelData = JsonUtility.FromJson<SavingData>(levelFileJsonContent);

		Player.inventory = levelData.playerInventory;
		player.gold = levelData.currency;
		player.xp = levelData.experience;
		player.health = levelData.health;

		var playerVector = GameObject.Find ("Player");

		playerVector.transform.Translate (levelData.playerPosition[0], levelData.playerPosition[1], levelData.playerPosition[2]);

		equipManag.currentEquipment = levelData.equipableItems;
		equipManag.UpdateUI ();

		Player.UpdateUI ();


	}

}
