using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D PlayerRB;
    private Vector3 move;

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if(move != Vector3.zero)
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
        PlayerRB.MovePosition(
            transform.position + move * speed * Time.deltaTime);
    }
}
