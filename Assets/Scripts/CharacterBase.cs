using System.Collections;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int jumps;
    public bool isOnGround;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
    }

    //Polymorphism, three types of Jump functions
    protected virtual void Jump(float jumpVerticalForce)
    {
        isOnGround = false;
        if (jumps == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpVerticalForce), ForceMode2D.Impulse);
        }
        jumps++;
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce)
    {
        isOnGround = false;
        if (jumps == 0) //First jump
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump1VerticalForce), ForceMode2D.Impulse);
        }
        else if (jumps == 1)//Second jump
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump2VerticalForce), ForceMode2D.Impulse);
        }
        jumps++;
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce, bool floatAbility)
    {
        isOnGround = false;
        if (jumps == 0) //First jump
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump1VerticalForce), ForceMode2D.Impulse);
        }
        else if (jumps == 1) //Second jump
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump2VerticalForce), ForceMode2D.Impulse);
                StartCoroutine(StartFloatation());
            }
        }
        jumps++;
    }

    IEnumerator StartFloatation()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

        while (Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<Rigidbody2D>().gravityScale = 0.33f;
        }
        GetComponent<Rigidbody2D>().gravityScale = 2f;
        yield break;
    }

    protected virtual void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;

        pos.x += horizontalInput * runSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
