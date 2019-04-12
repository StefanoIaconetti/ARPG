using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPC : Interactable
{

    XMLReader xmlReader = new XMLReader();


    public string nameOfCharacter;
    public string line;

    //Creates a text asset 
    public TextAsset xmlFile;

    //Name holds the name of the character, line holds their script
    public Text nameText;
    public Text lineText;
    

    //Grabs the name and the line
    protected string[] lineName;

    protected int endDialogue = 0;

    //Grabs the animator
    public Animator animator;

	Chest chest;
	ChestManager chestMang;
	ShopKeeperManager shopManag;
	ShopKeeperObject shopObj;


	public void Start (){
		shopManag = GameObject.Find("ShopKeeperManager").GetComponent<ShopKeeperManager>();
		chestMang = GameObject.Find("ChestManager").GetComponent<ChestManager>();
		shopObj = GetComponent<ShopKeeperObject>();
		chest = GetComponent<Chest>();
	}
    //When the NPC collides
    public void OnTriggerEnter2D(Collider2D character) {
        //When colliding with the player
		if (character.gameObject.name == "Player" && npcType != NPCType.Chest) {
			//Strings the data in the xmlFile
			string data = xmlFile.text;

			//Sets the name and line
			lineName = xmlReader.parseXml (data, nameOfCharacter);

			//If the NPC collides with player then collide is set to true.
			collide = true;
		} else {

			collide = true;
		}
    }

    //When the player is no longer in the collider
    public void OnTriggerExit2D(Collider2D other)
    {
		if (npcType != NPCType.Chest && npcType != NPCType.Crafter) {
			//The dialogue text goes down
			animator.SetBool ("IsOpen", false);
			collide = false;
			nameText.text = "";
		} else {
			collide = false;
		}
    }


    public void Update()
    {
        //When the e key is pressed dialogue occurs
        if (Input.GetKeyDown(GameManager.GM.use) && collide)
        {
			if (npcType == NPCType.Chest) {
				chestMang.inventoryCanOpen = true;
				chestMang.currentchest = chest;
				chestMang.CheckShopKeeper ();
				//chest.ShopOpen();

			} else {
				Triggered ();
			}

            if (endDialogue == 2 && npcType == NPCType.NPC)
            {
                animator.SetBool("IsOpen", false);
                nameText.text = "";
                endDialogue = 0;
            }else if(endDialogue == 2 && npcType == NPCType.Shopkeeper)
            {

				animator.SetBool("IsOpen", false);
				//nameText.text = "";
				shopManag.inventoryCanOpen = true;

				//ShopKeeperManager.currentShopKeeper = 

				//ShopKeeperManager.CheckShopKeeper ();
				shopManag.currentShopKeeper = shopObj;
				shopManag.CheckShopKeeper ();
				endDialogue = 0;


            } else if (endDialogue == 2 && npcType == NPCType.QuestGiver) {
                animator.SetBool("IsOpen", false);
                nameText.text = "";
                endDialogue = 0;
			}

        }
    }

    //Adds a delay when the text plays
    public IEnumerator SentenceWrite(string sentence)
    {
        
        lineText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            lineText.text += letter;
            yield return null;
        }
    }

    //When npc is triggered then make dialoge box show
    virtual public void Triggered() {
        animator.SetBool("IsOpen", true);
        nameText.text = lineName[0];
        StopAllCoroutines();
        StartCoroutine(SentenceWrite(lineName[1]));
        endDialogue++;
    }
}
