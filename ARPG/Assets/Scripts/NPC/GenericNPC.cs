using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : NPC {

    //variables
    public List<GameObject> targets;
    public bool IsWalking = false;
    private int counter = 0;
    public int speed;

    public Animator anim;
    public Rigidbody2D rb;

    public void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Create a NPC
    public GenericNPC() {
        nameOfCharacter = "genericnpc";
        npcType = NPCType.NPC;
    }

    private void Update() {
        if(targets.Count > 0) {
            //Move towards the first target
            Vector3 temp = Vector3.MoveTowards(transform.position, targets[counter].transform.position, speed * Time.deltaTime);
            ChangeAnimation(temp - transform.position);
            rb.MovePosition(temp);
            //Set its animator to play walking animations
            anim.SetBool("IsWalking", true);

            //Once npc reached the target. set the target to the next target
            if (transform.position == targets[counter].transform.position) {
                anim.SetBool("IsWalking", false);
                counter++;
            }

            //When it reaches the last target. reset the counter
            if (counter >= targets.Count) {
                counter = 0;
            }

        }
    }

    private void SetAnimatorFloat(Vector2 setVector) {
        anim.SetFloat("x", setVector.x);
        anim.SetFloat("y", setVector.y);
    }

    //Cheange animation depending on direction
    private void ChangeAnimation(Vector2 direction) {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if (direction.x > 0) {
                SetAnimatorFloat(Vector2.right);
            } else if (direction.x < 0) {
                SetAnimatorFloat(Vector2.left);
            }
        } else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
            if (direction.y > 0) {
                SetAnimatorFloat(Vector2.up);
            } else if (direction.y < 0) {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }


}
