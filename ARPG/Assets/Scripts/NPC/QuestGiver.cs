using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public GameObject questManager;

    public Quest quest;

    public Player player;
    public bool questGiven = false;
    public int level;

    //Create a quest
    private void Start() {
        CreateQuest();
    }
    //Give player a quest
    public void AcceptQuest() {
        if(!questGiven) {
            quest.isActive = true;
            //add the quest
            player.questList.Add(quest);
            questGiven = true;
        }
    }

    //Create a quest giver
    public QuestGiver() {
        nameOfCharacter = "questgiver";
        npcType = NPCType.QuestGiver;
    }

    //When triggered
    public override void Triggered() {
        base.Triggered();
        //Complete quests
        CompleteQuests();
        //give quest
        AcceptQuest();
    }

    //Function to create quest
    public void CreateQuest() {
        //Generate a random number (either 1 or 2)
        if (level > 0 && level <= 3) {
            int ranNum = Random.Range(1, 3);
            //if 1 generate a kill quest, if 2 generate a gather quest
            if(ranNum == 1) {
                quest = questManager.GetComponent<QuestManager>().GenerateKillQuest(level);
            } else if (ranNum == 2) {
                quest = questManager.GetComponent<QuestManager>().GenerateGatherQuest(level);
            }
        }
    }

    //Function to complete quests
    public void CompleteQuests() {
        //Check each quest that is active and completed
        foreach (Quest quest in player.questList) {
            if (quest.isComplete && quest.isActive) {
                //if its a gather quest
                if (quest.goal.goalType == GoalType.Gather) {
                    //remove the items from players inventory
                    Player.inventory.RemoveItem(quest.item);
                }
                //Give the player a reward
                Item reward = questManager.GetComponent<QuestManager>().GetLoot();
                InventoryItem item = new InventoryItem(reward, 1);
                Player.inventory.AddItem(item);
                Player.UpdateUI();
                //Player gains xp, gold and the quest gets completed
                player.GainXP(quest.xpReward);
                player.gold += quest.goldReward;
                quest.Complete();
            }
        }
    }


}
