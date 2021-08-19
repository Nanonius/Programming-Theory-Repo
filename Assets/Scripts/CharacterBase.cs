using System.Collections;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected bool jumped;
    public float runSpeed;
    public float rotationDistance;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        jumped = false;
    }

    //Polymorphism, three types of Jump functions
    protected virtual void Jump(float jumpVerticalForce)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpVerticalForce), ForceMode2D.Impulse);
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce)
    {
        if (jumped) //Second jump
        {
            jumped = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump2VerticalForce), ForceMode2D.Impulse);
        }
        else //First jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump1VerticalForce), ForceMode2D.Impulse);
        }
        jumped = true;
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce, bool floatAbility)
    {
        if (jumped) //Second jump
        {
            jumped = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump2VerticalForce), ForceMode2D.Impulse);
            while(Input.GetKey(KeyCode.Space))
            {
                Physics2D.gravity *= 0.1f;
            }
        }
        else //First jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump1VerticalForce), ForceMode2D.Impulse);
        }
        jumped = true;
    }

    protected virtual void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;

        pos.x += horizontalInput * runSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
