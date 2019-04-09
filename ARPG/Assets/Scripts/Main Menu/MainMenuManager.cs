using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public string sceneName = ""; 

	public void NewGame(){
		if(sceneName != ""){
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
	}

	public void LoadGame(){
		if(sceneName != ""){
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

			DontDestroyOnLoad (GameObject.Find("LoadChecker"));
		}
	}
}
