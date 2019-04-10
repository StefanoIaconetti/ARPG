using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    public Player player;
    public GameObject soundManager;
    public AudioClip townMusic;
    public AudioClip adventureMusic;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Set a bool in player to say he is in a town
        player.isInTown = true;

        //Tell the soundManager to play town music
        soundManager.GetComponent<SoundManager>().ChangeMusic(townMusic);
        
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //Set a bool in player to say he is no longer in a town
        player.isInTown = false;

        //Tell the soundManager to play adventure music
        soundManager.GetComponent<SoundManager>().ChangeMusic(adventureMusic);

    }
}
