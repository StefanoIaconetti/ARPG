using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract meaning it cant exist on its own
public abstract class Character : MonoBehaviour{

	[SerializeField]
	private float speed;
    public float health;
    public float maxHealth;
    public float xp;
    public float maxLevelXP;
    public float gold;
    public int level;
    public int maxLevel;
	protected Vector2 direction;
	private Rigidbody2D characterRigid;

    public bool isStaggered = false;

    protected Animator animator;

    public bool IsAttackingClose = false;
    public bool IsAttackingRanged = false;
    public bool IsMoving {
        get {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected Coroutine attackCloseCoroutine;
    protected Coroutine attackRangedCoroutine;


    void Start() {
        //Initializes variables
        level = 0;
        maxHealth = 50;
        maxLevel = 15;
        maxLevelXP = 100;
		characterRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
	}

	// Virtual update so it can be overridden
	protected virtual void Update() {
        HandleLayers();
        if (xp >= maxLevelXP) {
            LevelUp();
        }
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
        } else if (IsAttackingClose && !IsAttackingRanged && !isStaggered) {
            ActivateLayer("AttackClose");
        } else if (IsAttackingRanged && !IsAttackingClose && !isStaggered) {
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

    public void LevelUp() {
        //If not max level
        if(level < maxLevel) {

            //Upgrade health
            maxHealth += 10;
            health = maxHealth;

            //Reset XP
            if (level < 5) {
                maxLevelXP = ((float)(maxLevelXP * 2));                 //Lvl 0-4 - 100,200,400,800,1600
            } else if (level < 10) {
                maxLevelXP = ((float)(maxLevelXP * 1.3));               //Lvl 5-9 - 2080, 2704, 3515, 4569, 5940
            } else if (level < 15) {
                maxLevelXP = ((float)(maxLevelXP * 1.1));              //Lvl 10-14 - 6534, 7188, 7907, 8697, 9567
            }
            xp = 0;

            //Add level
            level++;
        }
    }

    public void GainXP(float xpGained) {
        xp += xpGained;
    }

}
