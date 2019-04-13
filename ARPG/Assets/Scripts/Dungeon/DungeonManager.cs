using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
	public GameObject[] dungeonPrefabs = new GameObject[4];
	public GameObject[] bossType = new GameObject[5];
	public GameObject currentDungeon;
	public int currentBoss;
	public GameObject bossRoom;
	public int roomCounter = 0;
	SoundManager soundManag;
	public AudioClip caveMusic;
	GameObject player;

    void Start()
    {
		RandomDungeon ();

		 player =  GameObject.Find("Player");

		player.transform.position = new Vector3(0,0,0);

		soundManag = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		//Tell the soundManager to play town music
		soundManag.GetComponent<SoundManager>().ChangeMusic(caveMusic);


    }

	public void RandomDungeon(){

		if(currentDungeon != null){
			GameObject current = GameObject.Find (currentDungeon.name + "(Clone)");
			Destroy (current);
		}

		if (roomCounter == 2) {
			Instantiate (bossRoom, transform.position, Quaternion.identity);
			Player playerScript = player.GetComponent<Player> ();
			BossManager bossManag = GameObject.Find ("BossManager").GetComponent<BossManager>();

			int bossNum = playerScript.bossNum;


			var bossVector = transform.position;

			bossVector.y += 10.08f;


			Instantiate (bossType [bossNum], bossVector, Quaternion.identity);
			currentBoss = bossNum;
		} else {


			int randomDungeonNum = Random.Range (0,3);

			currentDungeon = dungeonPrefabs [randomDungeonNum];

			Instantiate (currentDungeon, transform.position, Quaternion.identity);

		}

	}
}
