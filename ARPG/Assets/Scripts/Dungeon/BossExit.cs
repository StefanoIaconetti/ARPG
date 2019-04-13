using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExit : MonoBehaviour
{

	//When the player enters 
	void OnTriggerEnter2D(Collider2D collision)
	{	

		GameObject playerObj = GameObject.Find ("Player");
		GameObject managers = GameObject.Find ("Managers");
		GameObject canvas = GameObject.Find ("PlayerInventory");
		GameObject canvasUI = GameObject.Find ("CanvasUI");
		GameObject dungeonManag = GameObject.Find ("Dungeon Manager");
		DontDestroyOnLoad (dungeonManag);

		string fileSaveName = "playerinfo.json";

		Player player = GameObject.Find ("Player").GetComponent<Player>();
		EquipmentManager equipManag = GameObject.Find ("Managers/EquipmentManager").GetComponent<EquipmentManager>();

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


		SceneManager.LoadScene("MainScene");
		playerObj.name = "Destroy me";
		Destroy (managers);
		Destroy (canvas);
		Destroy (canvasUI);


	} 	
}
