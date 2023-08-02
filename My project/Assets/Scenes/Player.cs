using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public float jumpForce;

    public AudioSource atack;

    public GameObject bow;
    public Transform firePoint;

    private Rigidbody2D rig;
    private Animator anim;

    private bool isJumping;

    private bool doubleJump;
    private bool isFire;

    private float movement;
    public bool isRight;
    public Vector3 posInicial;

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

            isRight = true;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }

            isRight = false;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 0);
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
}
        