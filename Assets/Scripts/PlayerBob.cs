using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBob : CharacterBase //Inheritance
{
    private float speedMultiplier = 2f;
    private float jumpForce = 5f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run(speedMultiplier);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(rb.velocity.x < 0.1f)
        {
            Idle();
        }
    }

    private void Jump()
    {
        Jump(jumpForce); //Polymorphism
    }


    private void Run()
    {
        Run(speedMultiplier); //Polymorphism
    }

    protected override void Idle()
    {
        base.Idle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.coins++;
            GameManager.Instance.coinsText.text = $"Coins: {GameManager.Instance.coins} / 5";
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            GameManager.Instance.GameFinished();
        }
    }
}
