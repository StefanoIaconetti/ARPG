using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class XMLReader : MonoBehaviour {

    //Creates a text asset 
    public TextAsset xmlFile;
    public string charName = "";
    public string charLine = "";

    void Start() {
        //Strings the data in the xmlFile
        string data = xmlFile.text;

        //Parses using the method
        parseXml(data, "rock");
    }

    //Takes in the data from the xml file grabbing our script
    public string[] parseXml(string xmlScript, string character) {

       // string charName = "";
       // string charLine = "";

        //Creates a new xmlDoc
        XmlDocument xmlDoc = new XmlDocument();

        //Then loads the data passed
        xmlDoc.Load(new StringReader(xmlScript));

        //Path to the script
        string xmlScriptLocation = "//script/" + character;

        //Grabbing all data from script location
        XmlNodeList scriptNodeList = xmlDoc.SelectNodes(xmlScriptLocation);

        foreach (XmlNode node in scriptNodeList)
        {
            //Grabs the first node which is the name
            XmlNode name = node.FirstChild;

            //Grabs the second node which is the line
            XmlNode line = name.NextSibling;

            string[] nameLineArray = new string[] { name.InnerXml, line.InnerXml };

            //This returns the script given for their name and line
            return nameLineArray;
        }
        return null;
    }
}