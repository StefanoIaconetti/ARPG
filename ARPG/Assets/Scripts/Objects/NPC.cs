using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class NPC : CanInteract
{

    XMLReader xmlReader = new XMLReader();

    //Creates a text asset 
    public TextAsset xmlFile;

    //Name holds the name of the character, line holds their script
    public Text nameText;
    public Text lineText;
    //Seperates the strings
    string seperator = "|";

    //Grabs the name and the line
    string[] lineName;

    //Checks if they have collided
    bool collide = false;

    //Grabs the animator
    public Animator animator;

    //When the NPC collides
    void OnTriggerEnter2D(Collider2D character)
    {
        //When colliding with the player
        if (character.gameObject.name == "Player")
        {
            //Strings the data in the xmlFile
            string data = xmlFile.text;

            //Sets the name and line
            lineName = xmlReader.parseXml(data, name);

            //If the NPC collides with player then collide is set to true.
            collide = true;

        }
    }

    //When the player is no longer in the collider
    void OnTriggerExit2D(Collider2D other)
    {
        //The dialogue text goes down
        animator.SetBool("IsOpen", false);
    }


    void Update()
    {
        //When the e key is pressed dialogue occurs
        if (Input.GetKeyDown(KeyCode.E) && collide)
        {
            animator.SetBool("IsOpen", true);
            nameText.text = lineName[0];
            StopAllCoroutines();
            StartCoroutine(SentenceWrite(lineName[1]));
        }
    }

    //Adds a delay when the text plays
    IEnumerator SentenceWrite (string sentence)
    {
        lineText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            lineText.text += letter;
            yield return null;
        }
    }
}
