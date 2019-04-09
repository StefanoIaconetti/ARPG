﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterExit : MonoBehaviour
{

    private float playerX;
    private float playerY;

    // Start is called before the first frame update
    void Start()
    {
        if (ReachedBoss.isDone == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerX = DungeonTrigger.playerX - 1;
            playerY = DungeonTrigger.playery - 1;
            player.transform.position = new Vector2(playerX, playerY);
            ReachedBoss.isDone = false;
            Debug.Log(ReachedBoss.isDone);
        }
    }    
}