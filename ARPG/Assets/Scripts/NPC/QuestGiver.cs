using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public GameObject questManager;

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
        CompleteQuests();
        AcceptQuest();
    }

    public void CreateQuest() {
        if (level > 0 && level <= 3) {
            int ranNum = Random.Range(1, 3);
            if(ranNum == 1) {
                quest = questManager.GetComponent<QuestManager>().GenerateKillQuest(level);
            } else {
                //quest = questManager.GetComponent<QuestManager>().GenerateGatherQuest(level);
            }

        }
    }

    public void CompleteQuests() {
        foreach (Quest quest in player.questList) {
            if (quest.isComplete && quest.isActive) {
                if (quest.goal.goalType == GoalType.Gather) {
                    //remove the items from players inventory
                    Player.inventory.RemoveItem(quest.item);
                }

                player.GainXP(quest.xpReward);
                player.gold += quest.goldReward;
                quest.Complete();
            }
        }
    }


}
