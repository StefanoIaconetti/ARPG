using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public bool isIdle;
    public bool isWalking;
    Animator animator;
    SpriteRenderer sprite;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        sprite = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //Each input moves the character in a different direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isWalking = true;
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
            sprite.flipX = true;

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;

        }
      
        //If the GameObject is not walking, send that the Boolean “isWalking” is false to the Animator. The walking animation does not play.
        if (isWalking == false)
            animator.SetBool("IsWalking", false);

        //The GameObject is walking, so send the Boolean as enabled to the Animator. The walking animation plays.
        if (isWalking == true)
            animator.SetBool("IsWalking", true);
    }
}
