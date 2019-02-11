using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class NPC : CanInteract
{

    XMLReader xmlReader = new XMLReader();
    //Creates a text asset 
    public TextAsset xmlFile;
    public Text uiText;


    void OnTriggerEnter2D(Collider2D character)
    {

        uiText.text = "oooof";
        if (character.gameObject.name == "Player")
        {
            //Strings the data in the xmlFile
            string data = xmlFile.text;
            xmlReader.parseXml(data, name);
        }
    }
}
