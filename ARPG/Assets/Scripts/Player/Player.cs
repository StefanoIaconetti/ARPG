using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public List<Quest> questList;

    public bool isBoosted = false;
    public bool isInTown = true;

    public GameObject projectilePrefab;

    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;

	public int bossNum;

    // Update is called once per frame
    protected override void Update(){
		getInput();
		//Base means im accessing character
		base.Update();

	}


	public static string directionString = "Right";

	public static InventorySlot[] slots;


	public static Inventory inventory;

	public void Awake()
	{
		inventory = new Inventory();
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	//Parent items
	public Transform itemsParent;

	//Method that updates UI
	public static void UpdateUI() {

        //UPDATE GATHER QUESTS IN THE MOST RIDICULOUS WAY POSSIBLE
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().UpdateGatherQuests();
    
        //Goes through the amount of slots are in the inventory

		for (int i = 0; i < slots.Length; i++)
		{//If i is less than the amount in the inventory
			if (i < inventory.items.Count)
			{//Adds the item
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				//Clears the item
				slots[i].ClearSlot();
			}
		}
	}



    private void getInput(){
        //Resets direction
        direction = Vector2.zero;
		//Each input moves the character in a different direction
		if (Input.GetKey(GameManager.GM.right))
		{
			direction += Vector2.right;
			directionString = "Right";
		}
		else if (Input.GetKey(GameManager.GM.left))
		{
			direction += Vector2.left;
			directionString = "Left";
		}
		else if (Input.GetKey(GameManager.GM.forward))
		{
			direction += Vector2.up;
			directionString = "Up";
		}
		else if (Input.GetKey(GameManager.GM.backward))
		{
			direction += Vector2.down;
			directionString = "Down";
		}

        if (Input.GetKeyDown(GameManager.GM.attackClose)) {
            if (!IsAttackingClose) {
                attackCloseCoroutine = StartCoroutine(AttackClose());
            }
        }
        if (Input.GetKeyDown(GameManager.GM.attackRanged)) {
            if (!IsAttackingRanged) {
                attackRangedCoroutine = StartCoroutine(AttackRanged());
            }
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            if (!isBoosted && currentPotion != null) {
                //Use the function in the potion script UsePotion();
                //current potion is an equipable and i need it to be a potion?
            }
        }
    }

    private IEnumerator AttackClose() {
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            IsAttackingClose = true;
            animator.SetBool("attackClose", IsAttackingClose);
            yield return new WaitForSeconds(.7f);
            StopAttackClose();
        }
    }

    private IEnumerator AttackRanged() {
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            IsAttackingRanged = true;
            animator.SetBool("attackRanged", IsAttackingRanged);
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //Find direction
            Vector3 temp = FindDirection();
            //Shoot bubble
            projectile.GetComponent<Bubble>().Shoot(temp);
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
                        quest.isComplete = true;
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
                    //If the quests item name matches an item in the players inventory
                    foreach (InventoryItem item in inventory.items) {
                        if (quest.item.item.name == item.item.name ) {
                            //change the current amount to the quantity of that item in the players inventory
                            quest.goal.currentAmount = item.itemQuantity;
                        }
                    }


                    Debug.Log(quest.goal.currentAmount);
                    //If the goal is ever reached the player gains the rewards and ends the quest
                    if (quest.goal.isReached()) {
                        quest.isComplete = true;
                    }
                }
            }
        }
    }

    public Vector3 FindDirection() {

        Vector3 temp = new Vector3();

        switch(directionString) {
            case "Up":
                temp = upTarget.transform.position - transform.position;
                break;
            case "Down":
                temp = downTarget.transform.position - transform.position;
                break;
            case "Left":
                temp = leftTarget.transform.position - transform.position;
                break;
            case "Right":
                temp = rightTarget.transform.position - transform.position;
                break;
        }

        return temp;
    }

}