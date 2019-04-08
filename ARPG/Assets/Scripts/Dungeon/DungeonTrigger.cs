using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTrigger : MonoBehaviour
{
    
    public static float playerX;
    public static float playery;


    private GameObject player = null;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        playerX = player.transform.position.x;
        playery = player.transform.position.y;
        SceneManager.LoadScene("Dungeon");
    }
}