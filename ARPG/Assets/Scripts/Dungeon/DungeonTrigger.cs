﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//When the player enters the dungeon trigger radius
public class DungeonTrigger : MonoBehaviour
{
    //Grabs the players X and y positions
    public static float playerXPos;
    public static float playerYPos;

	//Grabs the gameobjects that wont be destroyed
	public GameObject playerObj;
	public GameObject managers;
	public GameObject canvas;
	public GameObject canvasUI;

    private GameObject player = null;

	//When the player enters 
     void OnTriggerEnter2D(Collider2D collision)
	{	DontDestroyOnLoad (playerObj);
		DontDestroyOnLoad (managers);
		DontDestroyOnLoad (canvas);
		DontDestroyOnLoad (canvasUI);

		playerXPos = playerObj.transform.position.x;
		playerYPos = playerObj.transform.position.y;
        SceneManager.LoadScene("Dungeon");


	} 	
}