using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    private bool isBob;
    private bool isJim;
    private bool isSuzy;
    // Start is called before the first frame update
    void Start()
    {
        isBob = false;
        isJim = false;
        isSuzy = false;
    }

    public void BobSelected()
    {
        isBob = true;
        isJim = false;
        isSuzy = false;

        StartGame();
    }

    public void JimSelected()
    {
        isBob = false;
        isJim = true;
        isSuzy = false;

        StartGame();
    }

    public void SuzySelected()
    {
        isBob = false;
        isJim = false;
        isSuzy = true;

        StartGame();
    }

    public void Play() //From title screen
    {
        //Show character selection screen
    }

    private void StartGame() //From character selection
    {
        if (isBob)
        {

        }
        else if(isJim)
        {

        }
        else if (isSuzy)
        {

        }
    }

    public void QuitGame()
    {

    }
}
