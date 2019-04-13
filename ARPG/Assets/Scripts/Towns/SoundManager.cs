using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip townClip;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = townClip;
        audioSource.Play();
    }

    //Function to change music
    public void ChangeMusic(AudioClip clip) {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

}
