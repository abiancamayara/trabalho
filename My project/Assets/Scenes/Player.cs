using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private Animator anim;

    private bool isJumping;

    private bool doubleJump;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            anim.SetInteger("transition", 2);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            doubleJump = true;
            isJumping = true;
        }
        else
        {
            if (doubleJump)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D coll)
    { 
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}