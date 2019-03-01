using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract meaning it cant exist on its own
public abstract class Character : MonoBehaviour{

	[SerializeField]
	private float speed;
	protected Vector2 direction;
	private Rigidbody2D characterRigid;

    protected Animator animator;

    protected bool IsAttackingClose = false;
    protected bool IsAttackingRanged = false;
    public bool IsMoving {
        get {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected Coroutine attackCloseCoroutine;
    protected Coroutine attackRangedCoroutine;


    void Start() {
		//Initializes the rigidbody
		characterRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

	// Virtual update so it can be overridden
	protected virtual void Update() {
        HandleLayers();
	}

    private void FixedUpdate() {
        MoveChar();
    }

    //Moves a character
    public void MoveChar() {
		characterRigid.velocity = direction.normalized * speed;
    }

    public void HandleLayers() {
        if (IsMoving) {
            ActivateLayer("Walk");
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
            StopAttackClose();
            StopAttackRanged();
        } else if (IsAttackingClose && !IsAttackingRanged) {
            ActivateLayer("AttackClose");
        } else if (IsAttackingRanged && !IsAttackingClose) {
            ActivateLayer("AttackRanged");
        } else {
            ActivateLayer("Idle");
        }
    }

    public void ActivateLayer(string layerName) {
        for (int i = 0; i < animator.layerCount; i++) {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    public void StopAttackClose() {
        if (attackCloseCoroutine != null) {
            StopCoroutine(attackCloseCoroutine);
            IsAttackingClose = false;
            animator.SetBool("attackClose", IsAttackingClose);
        }
    }

    public void StopAttackRanged() {
        if (attackRangedCoroutine != null) {
            StopCoroutine(attackRangedCoroutine);
            IsAttackingRanged = false;
            animator.SetBool("attackRanged", IsAttackingRanged);
        }
    }

}
