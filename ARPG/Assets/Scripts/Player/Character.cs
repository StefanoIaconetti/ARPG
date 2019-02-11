using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract meaning it cant exist on its own
public abstract class Character : MonoBehaviour{

	[SerializeField]
	private float speed;
	protected Vector2 direction;
	private Rigidbody2D characterRigid;

	
	void Start(){
		//Initializes the rigidbody
		characterRigid = GetComponent<Rigidbody2D>();
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

	}

}
