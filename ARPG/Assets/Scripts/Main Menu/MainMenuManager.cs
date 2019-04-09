using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This script is for the main menu where the player will be able to start a new game, load or go through settings
public class MainMenuManager : MonoBehaviour
{
	//Creates a scene name
	public string sceneName = ""; 

	//This is the onclick for NewGame
	public void NewGame(){
		//If the scene exists then it loads the scene
		if(sceneName != ""){
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
	}

	//This is the onclick for LoadGame
	public void LoadGame(){
		//If the scene exists then it loads the scene
		if(sceneName != ""){
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

			//Sends the loadchecker gameobject to the next scene which when the next scene
			DontDestroyOnLoad (GameObject.Find("LoadChecker"));
		}
	}
}
