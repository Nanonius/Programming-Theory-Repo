using UnityEngine;

public class PlayerSuzy : CharacterBase //Inheritance
{
    private float jumpForce1 = 6f;
    private float jumpForce2 = 2f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Jump(jumpForce1, jumpForce2, true); //Polymorphism
    }

    protected override void Run()
    {
        base.Run();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.coins++;
            GameManager.Instance.coinsText.text = $"Coins: {GameManager.Instance.coins} / 5";
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            GameManager.Instance.GameFinished();
        }
    }
}
