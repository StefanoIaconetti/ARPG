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
		ShopObject
    };

    //Checks if they have collided
    public bool collide = false;
    public NPCType npcType = NPCType.NPC;
}
