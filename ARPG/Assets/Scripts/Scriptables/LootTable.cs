using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Loot chance
[System.Serializable]
public class Loot {
    public Item loot;
    public int lootChance;
}

//Creats an item for the loot table
[CreateAssetMenu]
public class LootTable : ScriptableObject {
    public Loot[] loots;

    public Item LootItem() {
        int cumProb = 0;
        int currentProb = Random.Range(0, 100);

        for (int i = 0; i < loots.Length; i++) {
            cumProb += loots[i].lootChance;
            if (cumProb >= currentProb) {
                return loots[i].loot;
            }
        }


        return null;
    }

}
