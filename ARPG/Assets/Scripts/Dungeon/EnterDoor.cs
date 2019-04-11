using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour {
	
	public GameObject[] listOfEnemies;
	int counter;

	void OnCollisionEnter2D(Collision2D col) {
		for (int i = 0; i < listOfEnemies.Length; i++) {

			if(listOfEnemies[i] == null){
				counter++;
				Debug.Log (counter + listOfEnemies.Length);
			}


			if (col.gameObject.tag == "Player" && counter == listOfEnemies.Length) {
				counter = 0;
				Debug.Log ("Ooooofer tooofer");
				GameObject dungeonManag = GameObject.Find ("Dungeon Manager");
				DungeonManager dungeon = dungeonManag.GetComponent<DungeonManager> ();
				dungeon.RandomDungeon ();
				dungeon.roomCounter++;

			}
		}
	}


	}

