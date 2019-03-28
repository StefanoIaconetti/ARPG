using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    // Update is called once per frame
    protected override void Update(){
		getInput();
		//base means im accessing character
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
	public static void UpdateUI()
	{   //Goes through the amount of slots are in the inventory

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
		if (Input.GetKey(KeyCode.RightArrow))
		{
			direction += Vector2.right;
			directionString = "Right";
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction += Vector2.left;
			directionString = "Left";
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			direction += Vector2.up;
			directionString = "Up";
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			direction += Vector2.down;
			directionString = "Down";
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

    public void Knock(Rigidbody2D rb, float knockbackTime) {
        StartCoroutine(KnockCo(rb, knockbackTime));
    }

    //function to initiate a knockback timer
    private IEnumerator KnockCo(Rigidbody2D rb, float knockbackTime) {
        //if entity is not null initiate timer
        if (rb != null) {
            //wait the knockback time
            yield return new WaitForSeconds(knockbackTime);
            //set the entity back to its original state
            rb.velocity = Vector2.zero;
            //Switch staggerd state
            isStaggered = false;
        }
    }

}