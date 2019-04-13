using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

	public GameObject chest;
	Chest chestObject;
	public GameObject exit;
	DungeonManager dungeonManag;
	public GameObject[] bossPrefabs = new GameObject[4];
	int currentBoss;
	public Item[] bossItems;

	public void Start(){
		chest.SetActive (false);
		exit.SetActive (false);
		dungeonManag = GameObject.Find ("Dungeon Manager").GetComponent<DungeonManager> ();

		currentBoss = dungeonManag.currentBoss;
	}

	public void Final(){
		chest.SetActive (true);
		exit.SetActive (true);

		chestObject = GameObject.Find ("Chest").GetComponent<Chest> ();

		var bossVector = transform.position;

		bossVector.x += 10.08f;


		Instantiate (bossPrefabs [currentBoss], transform.position, Quaternion.identity);
		InventoryItem item = new InventoryItem (bossItems [currentBoss], 1);
		chestObject.inventory.items[0] = item;
	}
}
