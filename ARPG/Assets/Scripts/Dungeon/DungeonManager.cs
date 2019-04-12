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

		if (roomCounter == 3) {
			Instantiate (bossRoom, transform.position, Quaternion.identity);
			Player playerScript = player.GetComponent<Player> ();
			BossManager bossManag = GameObject.Find ("BossManager").GetComponent<BossManager>();

			int bossNum = playerScript.bossNum;

			switch (bossNum) {
			case 0:
				Instantiate (bossType [0], transform.position, Quaternion.identity);
				currentBoss = 0;
				break;

			case 1:
				Instantiate (bossType[1], transform.position, Quaternion.identity);
				currentBoss = 1;
				break;

			case 2:
				Instantiate (bossType[2], transform.position, Quaternion.identity);
				currentBoss = 2;
				break;

			case 3:
				Instantiate (bossType[3], transform.position, Quaternion.identity);
				currentBoss = 3;
				break;

			case 4:
				Instantiate (bossType[4], transform.position, Quaternion.identity);
				currentBoss = 4;
				break;
			}
		} else {


			int randomDungeonNum = Random.Range (0,3);

			currentDungeon = dungeonPrefabs [randomDungeonNum];

			Instantiate (currentDungeon, transform.position, Quaternion.identity);

		}

	}
}
