using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    //Start Game Function
    public void StartGame () {
        //Loads the main scene
        SceneManager.LoadScene("SampleScene");
    }

    //Exit Game Function
    public void ExitGame () {
        //Does no work while in unity only once deployed
        Application.Quit();
    }
}
