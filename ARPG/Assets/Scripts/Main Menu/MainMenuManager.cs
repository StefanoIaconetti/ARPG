using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This script is for the main menu where the player will be able to start a new game, load or go through settings
public class MainMenuManager : MonoBehaviour
{
    //Creates a scene name
    public string sceneName = "";

    public GameObject newButton;
    public GameObject loadButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject creditsText;



	public void OnExitApplication(){
		Application.Quit ();
	}

    //Escape will reset the buttons
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            newButton.SetActive(true);
            loadButton.SetActive(true);
            settingsButton.SetActive(true);
            creditsButton.SetActive(true);
            creditsText.SetActive(false);
        }
    }
    //This is the onclick for NewGame
    public void NewGame()
    {
        //If the scene exists then it loads the scene
        if (sceneName != "")
        {
            SceneManager.LoadScene("Opening", LoadSceneMode.Single);
        }
    
			//Sends the loadchecker gameobject to the next scene which when the next scene
			DontDestroyOnLoad (GameObject.Find("LoadChecker"));
		}


    //This is the onclick for LoadGame
    public void LoadGame()
    {
        //If the scene exists then it loads the scene
        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            //Sends the loadchecker gameobject to the next scene which when the next scene
            DontDestroyOnLoad(GameObject.Find("LoadChecker"));
        }
    }
    public void CreditsReal()
    {
        //Disabling the buttons
        newButton.SetActive(false);
        loadButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);

        //Enabling the Credits
        creditsText.SetActive(true);
    }
}
