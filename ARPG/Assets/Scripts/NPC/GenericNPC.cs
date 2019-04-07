using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : NPC {

    public List<GameObject> targets;
    public bool IsWalking = false;
    private int counter = 0;
    public int speed;

    public GenericNPC() {
        nameOfCharacter = "genericnpc";
        npcType = NPCType.NPC;
    }

    private void Update() {
        if(targets != null && IsWalking == false) {
            while(counter < targets.Count) {
                //Move towards the first target
                transform.position = Vector3.MoveTowards(transform.position, targets[counter].transform.position, speed * Time.deltaTime);

                //Once npc reached the target. set the target to the next target
                if(transform.position == targets[counter].transform.position) {
                    counter++;
                }

            }
            //When it reaches the last target. reset the counter
            if (counter >= targets.Count) {
                counter = 0;
            }

        }
    }


}
