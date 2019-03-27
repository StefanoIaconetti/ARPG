using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public Quest quest;

    public Player player;
    public bool questGiven = false;

    private void Start() {
        CreateQuest();
    }

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

    public void CreateQuest() {
        quest = new Quest();
        quest.goal.goalType = GoalType.Kill;
        quest.goal.requiredAmount = 3;
        quest.goldReward = 100;
        quest.xpReward = 100;
        quest.description = "A simple bounty";
        quest.title = "Test Quest";
    }
}
