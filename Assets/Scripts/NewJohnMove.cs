 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJohnMove : MonoBehaviour
{
    public float runSpeed=4;
    public float jumpSpeed = 10;
    Rigidbody2D rb2D;
    SpriteRenderer spRd;
    Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spRd.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        { 
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spRd.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
       
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }
    }
}
