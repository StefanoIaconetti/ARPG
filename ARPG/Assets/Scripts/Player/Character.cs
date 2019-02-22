using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract meaning it cant exist on its own
public abstract class Character : MonoBehaviour{

	[SerializeField]
	private float speed;
	protected Vector2 direction;
	private Rigidbody2D characterRigid;

    private Animator animator;

	
	void Start(){
		//Initializes the rigidbody
		characterRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

	// Virtual update so it can be overridden
	protected virtual void Update()
	{
		MoveChar();
	}

	//Moves a character
	public void MoveChar()
	{
		characterRigid.velocity = direction.normalized * speed;

        if (direction.x != 0 || direction.y != 0) {
            AnimateMovement();
        } else {
            animator.SetLayerWeight(1, 0);
        }


    }

    public void AnimateMovement() {

        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

}
