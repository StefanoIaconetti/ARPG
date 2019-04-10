using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	public GameObject[] dungeonPrefabs = new GameObject[4];
	public GameObject currentDungeon;
	public GameObject bossRoom;
	public int roomCounter = 0;

    void Start()
    {
		RandomDungeon ();

		GameObject player =  GameObject.Find("Player");
		player.transform.position = new Vector3(0,0,0);
    }



	public void RandomDungeon(){

		if(currentDungeon != null){
			GameObject current = GameObject.Find (currentDungeon.name + "(Clone)");
			Destroy (current);
		}

		if (roomCounter == 3) {
			Instantiate (bossRoom, transform.position, Quaternion.identity);
		} else {


			int randomDungeonNum = Random.Range (0,3);

			currentDungeon = dungeonPrefabs [randomDungeonNum];

			Instantiate (currentDungeon, transform.position, Quaternion.identity);

		}

	}
}
