using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	
    public float movementSpeed = 10f;
    Rigidbody2D rb;
    float movement = 0f;

    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText.text = 0+"";
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        CheckHeight();
    }

    void CheckHeight()
    {
        if ((int)transform.position.y > Int32.Parse(scoreText.text))
        {
            scoreText.text = (int)transform.position.y+"";
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    //collider trigger enter 2d tag death
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            //destroy game object
            Destroy(gameObject);
        }
    }
}
