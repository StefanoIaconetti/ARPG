using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    //This enum will identify who exactly the player is interacting with
    public enum NPCType
    {
        Shopkeeper,
        NPC,
        QuestGiver,
		Chest,
        Crafter,
<<<<<<< HEAD
		ShopObject
=======
        NPCNoTalk
>>>>>>> 876aa51a69a24b54c8f257576fdfa71fb489148f
    };

    //Checks if they have collided
    public bool collide = false;
    public NPCType npcType = NPCType.NPC;
}
