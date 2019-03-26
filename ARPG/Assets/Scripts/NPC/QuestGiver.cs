using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public Quest quest;

    public Player player;
    public bool questGiven = false;

    public void AcceptQuest() {
        if(!questGiven) {
            quest.isActive = true;
            player.questList.Add(quest);
            questGiven = true;
        }
    }

    public QuestGiver() {
        nameOfCharacter = "questgiver";
        npcType = NPCType.QuestGiver;
    }

    public override void Triggered() {
        base.Triggered();
        AcceptQuest();
    }
}
