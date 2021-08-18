using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Jump(int numberOfJumps, float jumpVerticalForce)
    {

    }

    protected virtual void Jump(int numberOfJumps, float jump1VerticalForce, float jump2VerticalForce)
    {

    }

    protected virtual void Jump(int numberOfJumps, float jump1VerticalForce, float jump2VerticalForce, bool floatAbility)
    {

    }

    protected virtual void Run()
    {

    }

    protected virtual void Idle()
    {
        //Rotate back and forth
    }
}
