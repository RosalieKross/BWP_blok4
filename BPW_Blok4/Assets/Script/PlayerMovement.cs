using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState // als een bool met meer functies
{
    walk,
    attack,
    interact,
    idle,
    stagger
}


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D PlayerRB;
    private Vector3 move;
    private Animator animator;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public VectorValue startingPosition;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;


    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        //is the player in an interacrion
        if(currentState == PlayerState.interact)
        {
            return;
        }


        move = Vector3.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Space") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }


    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
  
    }


    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receivedItem", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else // 
            {
                animator.SetBool("receivedItem", false);
                currentState = PlayerState.walk;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;

            }
        }

    }

    void UpdateAnimationAndMove()
    {
        if (move != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

    }
    

    void MoveCharacter()
    {
        move.Normalize();
        PlayerRB.MovePosition(
            transform.position + move * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RunTimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RunTimeValue > 0)
        {
            
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false); //bij gameover player niet actief
        }
    }

    public IEnumerator KnockCo(float knockTime)
    {
        if (PlayerRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            PlayerRB.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            PlayerRB.velocity = Vector2.zero;

        }
    }
}
