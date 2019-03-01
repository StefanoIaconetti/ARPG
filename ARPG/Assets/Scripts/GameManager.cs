using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas inventory;
    public bool inventoryOpen = false;

    void Start(){
        inventory.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        //This is with the inventory opening and closes
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inventoryOpen)
            {
                inventoryOpen = false;
                inventory.enabled = false;
                Time.timeScale = 1;
            }
            else
            {
                inventoryOpen = true;
                inventory.enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}
