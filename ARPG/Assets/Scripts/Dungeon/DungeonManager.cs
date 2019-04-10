using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	public GameObject[] dungeonPrefabs = new GameObject[4];
	public GameObject currentDungeon;
	int roomCounter = 0;

    void Start()
    {
		int randomDungeonNum = Random.Range (0,3);

		currentDungeon = dungeonPrefabs [randomDungeonNum];

		Instantiate (currentDungeon, transform.position, Quaternion.identity);

		GameObject player =  GameObject.Find("Player");
		player.transform.position = new Vector3(0,0,0);
    }
}
