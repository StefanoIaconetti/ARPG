using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {

    public Canvas canvas;
    protected StoryTextManager textManager;
    public GameObject blackBackground;
    public GameObject player;
    public GameObject player2;
    public GameObject ika;
    public GameObject ika2;
    public GameObject ika3;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public Camera camera;
    public AudioSource audio;

    public bool nextScene = false;
    public float timeInBetweenScenes;
    public float currentTime;
    public int counter = 0;


    private void Start() {
        currentTime = timeInBetweenScenes;
        textManager = canvas.GetComponent<StoryTextManager>();
        player.active = false;
        player2.active = false;
        ika.active = false;
        ika2.active = false;
        ika3.active = false;
        enemy.active = false;
        enemy2.active = false;
        enemy3.active = false;
        canvas.enabled = false;
        blackBackground.active = false;
        audio.Play();

        camera.transform.position = new Vector3(0, 8, -10);
    }

    private void Update() {

        currentTime -= Time.deltaTime;
        if (currentTime < 0) {
            counter++;
            currentTime = timeInBetweenScenes;
        }

        switch (counter) {
            case 0:
                canvas.enabled = true;
                textManager.nameText.text = "Ester";
                textManager.lineText.text = "Huh? ... Ika? Where did you go?";
                timeInBetweenScenes = 2;
                break;
            case 1:
                player.active = true;
                player.GetComponent<GenericNPC>().enabled = false;
                textManager.nameText.text = "Ester";
                textManager.lineText.text = "Ika?";
                timeInBetweenScenes = 1;
                break;
            case 2:
                canvas.enabled = false;
                player.GetComponent<Animator>().SetFloat("x", -1);
                break;
            case 3:
                player.GetComponent<Animator>().SetFloat("x", 1);
                timeInBetweenScenes = 2;
                break;
            case 4:
                player.GetComponent<GenericNPC>().enabled = true;
                timeInBetweenScenes = 1;
                break;
            case 5:
                camera.transform.position = new Vector3(80, -20, -10);
                player.active = false;
                ika.active = true;
                ika.GetComponent<GenericNPC>().enabled = false;
                player2.active = true;
                break;
            case 6:
                ika.GetComponent<Animator>().SetFloat("x", -1);
                break;
            case 7:
                ika.GetComponent<Animator>().SetFloat("x", 1);
                canvas.enabled = true;
                textManager.nameText.text = "Ester";
                textManager.lineText.text = "Is that you Ika?";
                break;
            case 8:
                ika.GetComponent<Animator>().SetFloat("x", -1);
                break;
            case 9:
                ika.GetComponent<Animator>().SetFloat("x", 1);
                break;
            case 10:
                textManager.nameText.text = "Ester";
                textManager.lineText.text = "Why are you out here all alone?";
                player2.GetComponent<GenericNPC>().enabled = false;
                player2.GetComponent<Animator>().SetBool("IsWalking", false);
                ika.GetComponent<Animator>().SetFloat("x", -1);
                timeInBetweenScenes = 3;
                break;
            case 11:
                canvas.enabled = false;
                ika.GetComponent<GenericNPC>().enabled = true;
                break;
            case 12:
                ika.GetComponent<GenericNPC>().enabled = false;
                canvas.enabled = true;
                ika.GetComponent<Animator>().SetBool("IsWalking", false);
                ika.GetComponent<Animator>().SetFloat("x", -1);
                textManager.nameText.text = "Ika";
                textManager.lineText.text = "Bloop!";
                break;
            case 13:
                ika.active = false;
                ika2.active = true;
                canvas.enabled = false;
                timeInBetweenScenes = 1;
                break;
            case 14:
                ika2.active = false;
                player2.active = false;
                camera.transform.position = new Vector3(100, -50, -10);
                ika3.active = true;
                enemy.active = true;
                enemy2.active = true;
                enemy3.active = true;
                ika3.GetComponent<Animator>().SetFloat("x", -1);
                break;
            case 15:
                ika3.GetComponent<Animator>().SetFloat("x", 1);
                break;
            case 16:
                canvas.enabled = true;
                textManager.nameText.text = "Ika";
                textManager.lineText.text = "BLOOOOOOOOOOP!!";
                timeInBetweenScenes = 2;
                break;
            case 17:
                blackBackground.active = true;
                break;
            case 18:
                textManager.nameText.text = "Ester";
                textManager.lineText.text = "NOOOOOOOOOOO!";
                break;
            case 19:
                SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
                break;
        }
    }

    public IEnumerator Wait(float time) {
        nextScene = false;
        yield return new WaitForSeconds(time);
        nextScene = true;
    }



}
