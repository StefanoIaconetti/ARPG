using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour {

    public Quest quest;

    public Player player;

    public void AcceptQuest() {
        quest.isActive = true;
        player.questList.Add(quest);
    }
}
