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

    PersistentData persistentData;

    // Start is called before the first frame update
    void Start()
    {
        persistentData = GameObject.Find("PersistentData").GetComponent<PersistentData>();
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

        persistentData.isNormalGame = true;
        persistentData.isSpeedrun = false;
    }

    public void PlaySpeedrun() //From title screen
    {
        startElementsGO.SetActive(false);
        characterSelectionGO.SetActive(true);

        persistentData.isNormalGame = false;
        persistentData.isSpeedrun = true;
    }

    private void StartGame() //From character selection
    {
        if (isBob)
        {
            persistentData.isBob = true;
            persistentData.isJim = false;
            persistentData.isSuzy = false;
        }
        else if(isJim)
        {
            persistentData.isBob = false;
            persistentData.isJim = true;
            persistentData.isSuzy = false;
        }
        else if (isSuzy)
        {
            persistentData.isBob = false;
            persistentData.isJim = false;
            persistentData.isSuzy = true;
        }
        SceneManager.LoadScene(1);
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
