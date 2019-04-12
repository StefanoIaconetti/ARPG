using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//This game managers handles most of the things occuring in the game, there will only be one gamemanager
public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode openInventory { get; set; }
    public KeyCode use { get; set; }
    public KeyCode attackClose { get; set; }
    public KeyCode attackRanged { get; set; }
    public KeyCode usePotion { get; set; }


    //This holds the players inventory
	public GameObject playerInventory;

	//This holds the players equipment
	public GameObject inventoryEquipment;

	//This checks to see if the inventory is open
    public static bool inventoryOpen = false;

	//This holds the equipment manager, there will only be one
	public EquipmentManager equipManag;

	//This holds the player object so we can save
	public Player player;

	//This holds the save button so when this button is pressed the game saves
	public GameObject saveButton;

    //This holds the settings button so when it is pressed it loads the settings window
    public GameObject saveButton1;

    //This holds the Settings Canvas
    public GameObject Settings;

	//This will check if there is currently a loading gameobject, if there is load the recent save
	private GameObject checkLoad;
	private GameObject checkDungeon;

	public string fileLoadName = @"/playerinfo.json";
	public string fileSaveName = "playerinfo.json";

	//When the game starts
    void Start(){
		//Inventory is no longer active same with inventory equipment
		playerInventory.SetActive (false);	
		inventoryEquipment.SetActive (false);

		//This populates the gameobject if it can find that they have loaded
		checkLoad = GameObject.Find ("LoadChecker");
		checkDungeon = GameObject.Find ("Dungeon Manager");

		if(checkDungeon){
			GameObject playerDestroy = GameObject.Find ("Destroy me");
			Destroy (playerDestroy);

			Load ();
			Destroy (checkDungeon);



			Player.UpdateUI ();
			equipManag.UpdateUI ();
		}


		//If they did just load in
		if (checkLoad) {
			Load ();
			//Both UI'S are updated so the player can see that their inventory and items are still there
			//equipManag.UpdateUI ();
			Player.UpdateUI ();

			//Destroys the checkload
			Destroy (checkLoad);
		}


    }

    void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }


        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        openInventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryKey", "F"));
        attackClose = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackCloseKey", "Z"));
        attackRanged = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackRangedKey", "X"));
        use = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useKey", "E"));
        usePotion = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("usePotion", "C"));

    }


    // Update is called once per frame
    void Update()
    {
        //This is with the inventory opening and closes
        if (Input.GetKeyDown(GM.openInventory))
        {
			//Either unpauses game or pauses game depending on the boolean statement
			//Game is paused and unpaused depending on if the inventory is active or not
			if (playerInventory.activeSelf)
            {
                inventoryOpen = false;
				playerInventory.SetActive (false);	
				inventoryEquipment.SetActive (false);	
                Time.timeScale = 1;
            }
            else
            {
                inventoryOpen = true;
				playerInventory.SetActive (true);	
				inventoryEquipment.SetActive (true);
                Time.timeScale = 0;
            }
        }

		//If the pause button is pressed (Esc) then the menu items are brought up
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (saveButton.activeSelf) {
				saveButton.SetActive (false);
                saveButton1.SetActive(false);
			} else {
				saveButton.SetActive (true);
                saveButton1.SetActive(true);
                Settings.SetActive(false);

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
		var savePath = System.IO.Path.Combine(Application.persistentDataPath, fileSaveName);

		//Writes the json data to the savepath
		System.IO.File.WriteAllText(savePath, jsonData);

		//Lets us know if the file as been saved
		Debug.Log("Level saved to " + savePath);

	}

    public void OnSettingButton()
    {
        saveButton.SetActive(false);
        saveButton1.SetActive(false);
        Settings.SetActive(true);
        //MenuScript.menuPanel.gameObject.SetActive(true);

        //Escape key will open or close the panel
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuScript.menuPanel.gameObject.activeSelf)
            MenuScript.menuPanel.gameObject.SetActive(true);
    }


	public void Load(){


		//This finds the file by using Application.data path then finds the file playerinfo.json
		var jsonContent = File.ReadAllText(Application.persistentDataPath + fileLoadName);
		var playerData = JsonUtility.FromJson<SavingData>(jsonContent);

		//This now sets all the values to the corresponding variables
		player.gold = playerData.currency;
		player.xp = playerData.experience;
		player.health = playerData.health;

		//Equipment that was worn last is now put back on the player
		equipManag.currentEquipment = playerData.equipableItems;

		Player.inventory = playerData.playerInventory;


		//Finds the player gameobject
		var playerVector = GameObject.Find ("Player");


		if (checkDungeon) {
			playerVector.transform.Translate (0, 0, 0);
		} else {

			//Translates the gameobject to the last saved position
			playerVector.transform.Translate (playerData.playerPosition[0], playerData.playerPosition[1], playerData.playerPosition[2]);


		}



	}

  }



