﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedBoss : MonoBehaviour
{

    private float playerX;
    private float playerY;

    public static bool isDone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0)
            {
                GameObject dungeon = GameObject.FindGameObjectWithTag("Dungeon");
                DungeonGeneration dungeonGeneration = dungeon.GetComponent<DungeonGeneration>();
                SceneManager.LoadScene("JustinScene");
                isDone = true;
            }
        }
    }
}