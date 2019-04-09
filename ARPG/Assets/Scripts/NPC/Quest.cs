 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {

    public bool isActive;
    public bool isComplete;

    public string title;
    public string description;
    public int goldReward;
    public int xpReward;

    public InventoryItem item;

    public QuestGoal goal;

    public void Complete() {
        isActive = false;
    }

    public Quest() {
        goal = new QuestGoal();
    }

}
