using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected bool jumped;

    // Start is called before the first frame update
    void Start()
    {
        jumped = false;
    }

    //Polymorphism, three types of Jump functions
    protected virtual void Jump(float jumpVerticalForce)
    {
        StopCoroutine(IdleRotation());
        GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, jumpVerticalForce), ForceMode2D.Impulse);
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce)
    {
        StopCoroutine(IdleRotation());
        if (jumped) //Second jump
        {
            jumped = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, jump2VerticalForce), ForceMode2D.Impulse);
        }
        else //First jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, jump1VerticalForce), ForceMode2D.Impulse);
        }
        jumped = true;
    }

    protected virtual void Jump(float jump1VerticalForce, float jump2VerticalForce, bool floatAbility)
    {
        StopCoroutine(IdleRotation());
        if (jumped) //Second jump
        {
            jumped = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, jump2VerticalForce), ForceMode2D.Impulse);
            while(Input.GetKey(KeyCode.Space))
            {
                Physics2D.gravity *= 0.1f;
            }
        }
        else //First jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, jump1VerticalForce), ForceMode2D.Impulse);
        }
        jumped = true;
    }

    protected virtual void Run(float speedMultiplier)
    {
        StopCoroutine(IdleRotation());
        float horizontalInput = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * speedMultiplier * Time.deltaTime, transform.position.y));
    }

    protected virtual void Idle()
    {
        StartCoroutine(IdleRotation());
    }

    private IEnumerator IdleRotation()
    {
        transform.Rotate(new Vector3(0, 0, 10f));
        yield return new WaitForSeconds(0.5f);
        transform.Rotate(new Vector3(0, 0, -15f));
        StartCoroutine(IdleRotation());
    }
}
