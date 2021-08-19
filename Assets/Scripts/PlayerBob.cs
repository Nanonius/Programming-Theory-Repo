using UnityEngine;

public class PlayerBob : CharacterBase //Inheritance
{
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Running();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Jump(jumpForce); //Polymorphism
    }

    private void Running()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;

        pos.x += horizontalInput * runSpeed * Time.deltaTime;
        transform.position = pos;
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
