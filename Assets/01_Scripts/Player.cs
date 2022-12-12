using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;
	Rigidbody2D rb;
	public Text scoreText;
	public Text prizeText;
	float movement = 0f;
	public float timer = 0;
	public float prizeTime = 3;
	public bool prizeReset = false;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		scoreText.text = 0+"";
		prizeText.text = "";
	}
	
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
		CheckHeight();
		CheckPrize();
		IsPrizeShown();
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
			//load game over scene
			SceneManager.LoadScene("GameOver");
        }
    }
	public void CheckHeight()
    {
        if ((int)transform.position.y > Int32.Parse(scoreText.text))
        {
            scoreText.text = (int)transform.position.y+"";
			PlayerPrefs.SetString("Score", scoreText.text);
        }
    }

	public void CheckPrize()
	{
		if (Int32.Parse(scoreText.text) == 50)
		{
			prizeText.text = "You won 5% Discount!";
			prizeReset = true;
		}
	}

	void IsPrizeShown()
	{
		if (prizeReset)
        {
            timer += Time.deltaTime;
			Debug.Log(timer);
            if (timer >= prizeTime)
			{
				timer = 0;
				prizeReset = false;
				prizeText.text = "";
			}
        }
	}
}
