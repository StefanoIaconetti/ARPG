using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterExit : MonoBehaviour
{

    private float playerX;
    private float playerY;
	DungeonTrigger dungeonTrigger;

    // Start is called before the first frame update
    void Start()
    {	
		DontDestroyOnLoad (dungeonTrigger.playerObj);
		DontDestroyOnLoad (dungeonTrigger.managers);
		DontDestroyOnLoad (dungeonTrigger.canvas);
		DontDestroyOnLoad (dungeonTrigger.canvasUI);

       // if (ReachedBoss.isDone == true)
       // {
         //   GameObject player = GameObject.FindGameObjectWithTag("Player");
         //   playerX = DungeonTrigger.playerXPos - 1;
          //  playerY = DungeonTrigger.playerYPos - 1;
           // player.transform.position = new Vector2(playerX, playerY);
          //  ReachedBoss.isDone = false;
           // Debug.Log(ReachedBoss.isDone);
       // }
    }    
}
