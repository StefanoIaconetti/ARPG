using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public LootTable questItems;
    public LootTable rewardLoot;

    //Generates a reward
    public Item GetLoot() {
        return rewardLoot.LootItem();
    }

    //Generate a kill quest
    public Quest GenerateKillQuest(int level) {
        int requiredNum = 0;
        int goldReward = 0;
        int xpReward = 0;

        //Create quest
        Quest quest = new Quest();
        quest.goal.goalType = GoalType.Kill;

        //Check level and randomize accordingly
        if (level == 1) {
            requiredNum = Random.Range(1, 3);
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

        //Give the quest the new values
        quest.goal.requiredAmount = requiredNum;
        quest.goldReward = goldReward;
        quest.xpReward = xpReward;
        quest.description = "Defeat " + requiredNum + " enemies!";
        quest.title = "Bounty Lvl: " + level;

        //return the created quest
        return quest;
    }

    //Generate gather quest
    public Quest GenerateGatherQuest(int level) {
        int requiredNum = 0;
        int goldReward = 0;
        int xpReward = 0;

        //Create quest
        Quest quest = new Quest();
        quest.goal.goalType = GoalType.Gather;

        //Check level and generate accordingly
        if (level == 1) {
            requiredNum = Random.Range(1, 3);
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

        //Generate random item here
        Item questItem = questItems.LootItem();
        InventoryItem item = new InventoryItem(questItem, 1);
        quest.item = item;

        //Set the quest values
        quest.goal.requiredAmount = requiredNum;
        quest.goldReward = goldReward;
        quest.xpReward = xpReward;
		quest.description = "Gather " + requiredNum + " " + item.item.name + "(s)";
        quest.title = "Gather Lvl: " + level;

        return quest;
    }
}
