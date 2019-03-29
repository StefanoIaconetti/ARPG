using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType {
    Kill,
    Gather
}

[System.Serializable]
public class QuestGoal : MonoBehaviour {

    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount = 0;

    public bool isReached() {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled() {
        if(goalType == GoalType.Kill) {
            Debug.Log("Incremented");
            currentAmount++;
        }
    }

    public void GatheredResource() {
        if(goalType == GoalType.Gather) {
            currentAmount++;
        }
    }

}
