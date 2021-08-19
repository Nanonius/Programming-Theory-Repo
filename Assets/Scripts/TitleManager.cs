using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleManager : MonoBehaviour
{
    private bool isBob;
    private bool isJim;
    private bool isSuzy;

    public GameObject startElementsGO;
    public GameObject characterSelectionGO;


    // Start is called before the first frame update
    void Start()
    {
        startElementsGO.SetActive(true);
        characterSelectionGO.SetActive(false);

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

    public void PlayNormal() //From title screen
    {
        startElementsGO.SetActive(false);
        characterSelectionGO.SetActive(true);

        GameManager.Instance.isNormalGame = true;
        GameManager.Instance.isSpeedrun = false;
    }

    public void PlaySpeedrun() //From title screen
    {
        startElementsGO.SetActive(false);
        characterSelectionGO.SetActive(true);

        GameManager.Instance.isNormalGame = false;
        GameManager.Instance.isSpeedrun = true;
    }

    private void StartGame() //From character selection
    {
        if (isBob)
        {
            GameManager.Instance.isBob = true;
            GameManager.Instance.isJim = false;
            GameManager.Instance.isSuzy = false;
        }
        else if(isJim)
        {
            GameManager.Instance.isBob = false;
            GameManager.Instance.isJim = true;
            GameManager.Instance.isSuzy = false;
        }
        else if (isSuzy)
        {
            GameManager.Instance.isBob = false;
            GameManager.Instance.isJim = false;
            GameManager.Instance.isSuzy = true;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
