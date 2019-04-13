using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCanvasManager : MonoBehaviour {
    protected Player player;
    public GameObject panelPrefab;
    public List<GameObject> questSpots;

    public int counter = 0;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void ShowQuests() {
        counter = 0;
        //Delete all prefabs
        //Check each slot
        foreach (GameObject slot in questSpots) {
            foreach (Transform child in slot.transform) {
                Destroy(child.gameObject);
            }
        }
        //Delete all children from the slot

        //Add quest prefabs
        foreach (Quest quest in player.questList) {
            if (counter < questSpots.Count) {
                if (quest.isActive) {
                    //Generate a panel prefab
                    GameObject panel = Instantiate(panelPrefab, questSpots[counter].transform);

                    //Set the texts that are in the panel with quest information
                    TextManager textManager = panel.GetComponent<TextManager>();
                    textManager.title.text = quest.title;
                    textManager.description.text = quest.description;
                    textManager.goldReward.text = "Gold: " + quest.goldReward;
                    textManager.xpReward.text = "XP: " + quest.xpReward;
                    counter++;
                }
            }

        }
    }

}
