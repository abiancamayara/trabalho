using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float speed;
    public float walktime;

    private float timer;
    private bool walkRight = true;

    public int health;
    public int damage = 1;

    private Animator anim;
    private Animator hit;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hit = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walktime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}