using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public List<Item> itemList = new List<Item>();


    public Quest GenerateKillQuest(int level) {
        int requiredNum = 0;
        int goldReward = 0;
        int xpReward = 0;

        Quest quest = new Quest();
        quest.goal.goalType = GoalType.Kill;

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

        quest.goal.requiredAmount = requiredNum;
        quest.goldReward = goldReward;
        quest.xpReward = xpReward;
        quest.description = "Defeat " + requiredNum + " enemies!";
        quest.title = "Bounty Lvl: " + level;

        return quest;
    }

    public Quest GenerateGatherQuest(int level) {
        int requiredNum = 0;
        int goldReward = 0;
        int xpReward = 0;

        Quest quest = new Quest();
        quest.goal.goalType = GoalType.Gather;

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
        InventoryItem item = new InventoryItem(itemList[0] , 1);
        quest.item = item;

        quest.goal.requiredAmount = requiredNum;
        quest.goldReward = goldReward;
        quest.xpReward = xpReward;
		quest.description = "Gather " + requiredNum + " " + item.item.name + "(s)";
        quest.title = "Gather Lvl: " + level;

        return quest;
    }
}
