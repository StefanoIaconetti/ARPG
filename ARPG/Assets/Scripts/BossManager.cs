using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

	public GameObject chest;
	GameObject currentBoss;

	public void Start(){

		currentBoss = GameObject.Find ("DungeonManager").GetComponent<DungeonManager> ().currentBoss;
	}

	public void Final(){
		chest.SetActive (true);


		//Instantiate (bossType [0], transform.position, Quaternion.identity);





	}
}
