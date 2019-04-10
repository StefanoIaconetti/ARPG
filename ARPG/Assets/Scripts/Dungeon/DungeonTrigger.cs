using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//When the player enters the dungeon trigger radius
public class DungeonTrigger : MonoBehaviour
{
    //Grabs the players X and y positions
    public static float playerXPos;
    public static float playerYPos;

	public GameObject playerObj;
	public GameObject managers;
	public GameObject canvas;
	public GameObject canvasUI;

    private GameObject player = null;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

     void OnTriggerEnter2D(Collider2D collision)
	{	DontDestroyOnLoad (playerObj);
		DontDestroyOnLoad (managers);
		DontDestroyOnLoad (canvas);
		DontDestroyOnLoad (canvasUI);

		playerXPos = player.transform.position.x;
		playerYPos = player.transform.position.y;
        SceneManager.LoadScene("Dungeon");


	} 	
}