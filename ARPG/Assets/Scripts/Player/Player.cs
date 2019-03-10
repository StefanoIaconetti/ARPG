using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {

    public float health;
    protected float maxHealth;

    // Update is called once per frame
    protected override void Update(){
		getInput();
		//base means im accessing character
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
            this.gameObject.SetActive(false);
        }
    }

}