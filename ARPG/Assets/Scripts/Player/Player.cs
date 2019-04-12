using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    //Variables
    public List<Quest> questList;

    public bool isBoosted = false;
    public bool isInTown = true;

    public GameObject projectilePrefab;

    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;

	public int bossNum;
    public EquipmentManager equipmentManager;

	public static string directionString = "Right";

	public static InventorySlot[] slots;


	public static Inventory inventory;

    // Update is called once per frame
    protected override void Update() {
        getInput();
        //Base means im accessing character
        base.Update();

    }

    //Setting up inventory
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


    //This checks which key the player presses
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
                //Use the function in the equipment manager UsePotion();
                equipmentManager.UsePotion(currentPotion);
            }
        }
    }

    //Attack close coroutine
    private IEnumerator AttackClose() {
        //if the player is allowed to attack
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            //Have player attack
            IsAttackingClose = true;
            animator.SetBool("attackClose", IsAttackingClose);
            //Wait a bit
            yield return new WaitForSeconds(.7f);
            //Stop the attack
            StopAttackClose();
        }
    }

    //Attack Ranged Coroutine
    private IEnumerator AttackRanged() {
        //If player is allowed to attack
        if (!IsAttackingClose && !IsAttackingRanged && !IsMoving) {
            //Attack
            IsAttackingRanged = true;
            animator.SetBool("attackRanged", IsAttackingRanged);
            //Create magic bubble
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //Find direction
            Vector3 temp = FindDirection();
            //Shoot bubble
            projectile.GetComponent<Bubble>().Shoot(temp);
            //Wait
            yield return new WaitForSeconds(.6f);
            //Stopattack
            StopAttackRanged();
        }
    }

    public void TakeDamage(float damage) {
        //If player has protection
        if (protection != 0) {
            //Protection is an int display of how much percentage is taken off an enemies attack
            //Turn to decimal
            float calculation = protection / 100f;
            //find how much health the players protection saved
            float damageDifference = damage * calculation;
            //take it away from the enemies damage
            float finalDamage = damage - damageDifference;
            //round it to nearst whole number
            finalDamage = (int)Mathf.Round(finalDamage);
            //Player takes damage from the new damage
            health -= finalDamage;
        } else {
            //Just take the damage
            health -= damage;
        }

        //If any point the player dies
        if (health <= 0) {
            //Display her death

            //Reset the player health and spawn her back at the player shop

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

    //Updates Kill quests
    public void UpdateKillQuests() {
        //Check each active quest
        foreach (Quest quest in questList) {
            if (quest.isActive) {
                //If its a kill quest
                if (quest.goal.goalType == GoalType.Kill) {
                    //Update the number of killed enemies
                    quest.goal.EnemyKilled();
                    //If the goal is ever reached the player gains the rewards and ends the quest
                    if (quest.goal.isReached()) {
                        quest.isComplete = true;
                    }
                }
            }
        }
    }

    //Update gather quests
    public void UpdateGatherQuests() {
        //Check each active gather quest
        foreach (Quest quest in questList) {
            if (quest.isActive) {
                if (quest.goal.goalType == GoalType.Gather) {
                    //If the quests item name matches an item in the players inventory
                    foreach (InventoryItem item in inventory.items) {
                        if (quest.item.item.name == item.item.name ) {
                            //change the current amount to the quantity of that item in the players inventory
                            quest.goal.currentAmount = item.itemQuantity;
                        }
                    }

                    //If the goal is ever reached the player gains the rewards and ends the quest
                    if (quest.goal.isReached()) {
                        quest.isComplete = true;
                    }
                }
            }
        }
    }

    //Function to find the direction the player is facing
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