using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

	public GameObject chest;
	DungeonManager dungeonManag;
	public GameObject[] bossPrefabs = new GameObject[4];
	int currentBoss;


	public void Start(){
		chest.SetActive (false);
		dungeonManag = GameObject.Find ("DungeonManager").GetComponent<DungeonManager> ();
		currentBoss = dungeonManag.currentBoss;
	}

	public void Final(){
		chest.SetActive (true);

		switch (currentBoss) {
		case 0:

			Instantiate (bossPrefabs [0], transform.position, Quaternion.identity);
			break;

		case 1:

			Instantiate (bossPrefabs [1], transform.position, Quaternion.identity);
			break;

		case 2:

			Instantiate (bossPrefabs [2], transform.position, Quaternion.identity);
			break;

		case 3:

			Instantiate (bossPrefabs [3], transform.position, Quaternion.identity);
			break;

		case 4:

			Instantiate (bossPrefabs [4], transform.position, Quaternion.identity);
			break;
		}





	}
}
