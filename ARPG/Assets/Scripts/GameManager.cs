using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas inventory;
	public Canvas inventoryEquipment;

    public static bool inventoryOpen = false;

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





}
