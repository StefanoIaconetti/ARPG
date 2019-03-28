using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public Quest quest;

    public Player player;
    public bool questGiven = false;
    public int level;

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
        if (level > 0 && level <= 3) {
            GenerateKillQuest(level);
        }
    }

    public void GenerateKillQuest(int level) {
        int requiredNum = 0;
        int goldReward = 0;
        int xpReward = 0;

        quest = new Quest();
        quest.goal.goalType = GoalType.Kill;

        if (level == 1) {
            requiredNum = Random.Range(1,3);
            goldReward = Random.Range(100, 200);
            xpReward = Random.Range(50, 100);
        } else if (level == 2) {
            requiredNum = Random.Range(5, 10);
            goldReward = Random.Range(200, 400);
            xpReward = Random.Range(100, 200);
        } else if (level == 3) {
            requiredNum = Random.Range(20, 50);
            goldReward = Random.Range(400, 600);
            xpReward = Random.Range(400, 500);
        }

        quest.goal.requiredAmount = requiredNum;
        quest.goldReward = goldReward;
        quest.xpReward = xpReward;
        quest.description = "Defeat " + requiredNum + " enemies!";
        quest.title = "Bounty Lvl: " + level;
    }
    
}
