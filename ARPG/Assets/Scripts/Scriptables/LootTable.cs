using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot {
    public Item loot;
    public int lootChance;
}


[CreateAssetMenu]
public class LootTable : ScriptableObject {
    public Loot[] loots;

    public Item LootItem() {
        int cumProb = 0;
        int currentProb = Random.Range(0, 100);

        for (int i = 0; i < loots.Length; i++) {
            Debug.Log("cumilitive " + cumProb + " current " + currentProb);
            cumProb += loots[i].lootChance;

            if (cumProb <= currentProb) {
                return loots[i].loot;
            }
        }


        return null;
    }

}
