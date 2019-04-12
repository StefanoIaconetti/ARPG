using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public static Transform menuPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;


	void Start ()
	{
		//Assign Settings to the Panel object in our Canvas
		menuPanel = transform.Find("Panel");
		//menuPanel.gameObject.SetActive(false);
		waitingForKey = false;

		//This for loop will go through each key that can be assigned and set the buttons text to the currently assigned key
		for(int i = 0; i < menuPanel.childCount; i++)
		{
			if(menuPanel.GetChild(i).name == "ForwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.forward.ToString();
			else if(menuPanel.GetChild(i).name == "BackwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.backward.ToString();
			else if(menuPanel.GetChild(i).name == "LeftKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
			else if(menuPanel.GetChild(i).name == "RightKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
			else if(menuPanel.GetChild(i).name == "openInventory")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.openInventory.ToString();
            else if (menuPanel.GetChild(i).name == "use")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.use.ToString();
            else if (menuPanel.GetChild(i).name == "usePotion")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.usePotion.ToString();
            else if (menuPanel.GetChild(i).name == "attackClose")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.attackClose.ToString();
            else if (menuPanel.GetChild(i).name == "attackRanged")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.attackRanged.ToString();
        }
	}


	public void Open ()
	{
		//Escape key will open or close the panel
        menuPanel.gameObject.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
			menuPanel.gameObject.SetActive(false);
	}

	void OnGUI()
	{
		//Used to detect the current event
		keyEvent = Event.current;

		//Executes if a button gets pressed and the user presses a key
		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
			waitingForKey = false;
		}
	}

	//Start assignment function to assign the key pressed to the selected key
	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}

	//Sets the buttons text with the key name
	public void SendText(Text text)
	{
		buttonText = text;
	}

	//Waiting for the key to be pressed
	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
			yield return null;
	}

	
	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey(); //Executes endlessly until user presses a key

		switch(keyName)
		{
		case "forward":
			GameManager.GM.forward = newKey; //Set forward to new keycode
			buttonText.text = GameManager.GM.forward.ToString(); //Set button text to new key
			PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString()); //save new key to PlayerPrefs
			break;
		case "backward":
			GameManager.GM.backward = newKey; //set backward to new keycode
			buttonText.text = GameManager.GM.backward.ToString(); //set button text to new key
			PlayerPrefs.SetString("backwardKey", GameManager.GM.backward.ToString()); //save new key to PlayerPrefs
			break;
		case "left":
			GameManager.GM.left = newKey; //set left to new keycode
			buttonText.text = GameManager.GM.left.ToString(); //set button text to new key
			PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString()); //save new key to playerprefs
			break;
		case "right":
			GameManager.GM.right = newKey; //set right to new keycode
			buttonText.text = GameManager.GM.right.ToString(); //set button text to new key
			PlayerPrefs.SetString("rightKey", GameManager.GM.right.ToString()); //save new key to playerprefs
			break;
		case "openInventory":
			GameManager.GM.openInventory = newKey; //set jump to new keycode
			buttonText.text = GameManager.GM.openInventory.ToString(); //set button text to new key
			PlayerPrefs.SetString("openInventory", GameManager.GM.openInventory.ToString()); //save new key to playerprefs
			break;
        case "useKey":
            GameManager.GM.use = newKey; //set jump to new keycode
            buttonText.text = GameManager.GM.use.ToString(); //set button text to new key
            PlayerPrefs.SetString("useKey", GameManager.GM.use.ToString()); //save new key to playerprefs
            break;
        case "usePotion":
            GameManager.GM.usePotion = newKey; //set jump to new keycode
            buttonText.text = GameManager.GM.usePotion.ToString(); //set button text to new key
            PlayerPrefs.SetString("usePotionKey", GameManager.GM.usePotion.ToString()); //save new key to playerprefs
            break;
        case "attackClose":
            GameManager.GM.attackClose = newKey; //set jump to new keycode
            buttonText.text = GameManager.GM.attackClose.ToString(); //set button text to new key
            PlayerPrefs.SetString("attackCloseKey", GameManager.GM.attackClose.ToString()); //save new key to playerprefs
            break;
        case "attackRanged":
            GameManager.GM.attackRanged = newKey; //set jump to new keycode
            buttonText.text = GameManager.GM.attackRanged.ToString(); //set button text to new key
            PlayerPrefs.SetString("attackRangedKey", GameManager.GM.attackRanged.ToString()); //save new key to playerprefs
            break;

        }

		yield return null;
	}
}
