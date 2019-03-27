using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public List<Quest> questList;

    // Update is called once per frame
    protected override void Update(){
		getInput();
		//Base means im accessing character
		base.Update();

	}

    private void getInput(){
        //Resets direction
        direction = Vector2.zero;
		//Each input moves the character in a different direction
		if (Input.GetKey(KeyCode.RightArrow))
		{
            direction += Vector2.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
            direction += Vector2.left;
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
            direction += Vector2.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
            direction += Vector2.down;
		}

        if (Input.GetKeyDown(KeyCode.Z)) {
            attackCloseCoroutine = StartCoroutine(AttackClose());
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            attackRangedCoroutine = StartCoroutine(AttackRanged());
        }
    }

    private IEnumerator AttackClose() {
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            IsAttackingClose = true;
            animator.SetBool("attackClose", IsAttackingClose);
            yield return new WaitForSeconds(.4f);
            StopAttackClose();
        }
    }

    private IEnumerator AttackRanged() {
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            IsAttackingRanged = true;
            animator.SetBool("attackRanged", IsAttackingRanged);
            yield return new WaitForSeconds(.6f);
            StopAttackRanged();
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //This is happening before healthbar script can get rid of the healthbar NEEDS FIX
            //this.gameObject.SetActive(false);

        }
    }

    //Function that will knock the player back
    public void Knock(Rigidbody2D rb, float knockbackTime) {
        StartCoroutine(KnockCo(rb, knockbackTime));
    }

    //Function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D rb, float knockbackTime) {
        //If player is not null initiate timer
        if (rb != null) {
            //Wait the knockback time
            yield return new WaitForSeconds(knockbackTime);
            //Set the player back to its original state
            rb.velocity = Vector2.zero;
            //Switch staggerd state
            isStaggered = false;
        }
    }

    public void UpdateKillQuests() {
        foreach (Quest quest in questList) {
            if (quest.isActive) {
                if (quest.goal.goalType == GoalType.Kill) {
                    Debug.Log("Killed an enemy");
                    quest.goal.EnemyKilled();

                    Debug.Log(quest.goal.currentAmount);
                    //If the goal is ever reached the player gains the rewards and ends the quest
                    if (quest.goal.isReached()) {
                        GainXP(quest.xpReward);
                        gold += quest.goldReward;
                        quest.Complete();
                    }
                }
            }
        }
    }

    public void UpdateGatherQuests() {
        foreach (Quest quest in questList) {
            if (quest.isActive) {
                if (quest.goal.goalType == GoalType.Gather) {
                    Debug.Log("Gathered");
                    quest.goal.GatheredResource();

                    Debug.Log(quest.goal.currentAmount);
                    //If the goal is ever reached the player gains the rewards and ends the quest
                    if (quest.goal.isReached()) {
                        GainXP(quest.xpReward);
                        gold += quest.goldReward;
                        quest.Complete();
                    }
                }
            }
        }
    }

}