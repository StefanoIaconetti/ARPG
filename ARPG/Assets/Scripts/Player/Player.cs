using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    //private Animator animator;
    //public bool isIdle;
    //public bool isWalking;

   
    // Update is called once per frame
    protected override void Update(){
		getInput();
		//base means im accessing character
		base.Update();

	}

    //private void Awake()
    //{
    //    animator = GetComponent<Animator>();
    //}

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
    }

}