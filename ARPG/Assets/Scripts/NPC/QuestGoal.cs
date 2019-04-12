using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType {
    Kill,
    Gather
}

[System.Serializable]
public class QuestGoal  {

    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount = 0;

    //If quest goal is reached
    public bool isReached() {
        return (currentAmount >= requiredAmount);
    }

    //If an enemy is killed add 1 to current amount
    public void EnemyKilled() {
        if(goalType == GoalType.Kill) {
            currentAmount++;
        }
    }

    //If resource is gathered add 1 to current amount
    public void GatheredResource() {
        if(goalType == GoalType.Gather) {
            currentAmount++;
        }
    }

}
