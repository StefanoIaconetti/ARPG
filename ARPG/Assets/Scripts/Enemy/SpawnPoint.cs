using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject[] monsters;

    public float maxSpawnedEnemies;
    protected float totalEnemies;

    public float timeInBetweenSpawns;
    public float nextSpawnTime;

    private int randomMonster;

    // Update is called once per frame
    void Update() {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (totalEnemies < maxSpawnedEnemies) {
            if (Time.time > nextSpawnTime) {
                //Generate a random number
                randomMonster = Random.Range(0, monsters.Length);
                //Instantiate the monster
                Instantiate(monsters[randomMonster], gameObject.transform.position, Quaternion.identity);

                //Reset the next spawn time
                nextSpawnTime = Time.time + timeInBetweenSpawns;
            }
        }
    }
}
