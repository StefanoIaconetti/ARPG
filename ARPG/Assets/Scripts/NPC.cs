using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class NPC : CanInteract
{

    XMLReader xmlReader = new XMLReader();
    //Creates a text asset 
    public TextAsset xmlFile;
    public Text nameText;
    public Text lineText;
    string seperator = "|";
    string[] lineName;
    bool collide = false;

    void OnTriggerEnter2D(Collider2D character)
    {

        if (character.gameObject.name == "Player")
        {
            //Strings the data in the xmlFile
            string data = xmlFile.text;


            lineName = xmlReader.parseXml(data, name);

            collide = true;

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collide)
        {
            Debug.Log("woop");
            nameText.text = lineName[0];
            lineText.text = lineName[1];
        }
    }
}
