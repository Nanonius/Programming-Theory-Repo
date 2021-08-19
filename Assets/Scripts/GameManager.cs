using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Arrays
    public GameObject[] coinsGOArray;

    //Characters
    public GameObject bobGO;
    public GameObject jimGO;
    public GameObject suzyGO;
    private GameObject BOB;
    private GameObject JIM;
    private GameObject SUZY;

    //Highscore Table variables
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI player3Text;
    [HideInInspector]
    public float timePlayer1;
    [HideInInspector]
    public float timePlayer2;
    [HideInInspector]
    public float timePlayer3;
    public TextMeshProUGUI timePlayer1Text;
    public TextMeshProUGUI timePlayer2Text;
    public TextMeshProUGUI timePlayer3Text;

    public TextMeshProUGUI currentPlayerRankingText;
    public TextMeshProUGUI currentPlayerNameText;
    public TextMeshProUGUI timeCurrentPlayerText;

    public TextMeshProUGUI enteredName;

    //Gameobjects
    public GameObject finishedObjectsGO;
    public GameObject speedrunObjectsGO;
    public GameObject highscoreTableObjectsGO;
    public GameObject coinsGO;

    //Text
    public TextMeshProUGUI finishedText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinsText;

    //Bools
    public bool isBob;
    public bool isJim;
    public bool isSuzy;

    public bool isNormalGame;
    public bool isSpeedrun;

    //Ints
    private int m_coins;
    public int coins //Encapsulation
    {
        get
        {
            return m_coins;
        }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("the number of coins can't be negative!");
            }
            else
            {
                m_coins = value;
            }
        }
    }

    //Floats
    private float m_timer;
    public float timer //Encapsulation
    {
        get
        {
            return m_timer;
        }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("the timer can't be negative!");
            }
            else
            {
                m_timer = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            Instance = this;
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        finishedObjectsGO.SetActive(false);
        speedrunObjectsGO.SetActive(false);
        highscoreTableObjectsGO.SetActive(false);

        if (isNormalGame)
        {
            NormalGameSetup(); //Abstraction
        }
        else if (isSpeedrun)
        {
            SpeedrunGameSetup(); //Abstraction
        }
    }

    private void NormalGameSetup()
    {
        isNormalGame = true;
        m_coins = 0;
        foreach (GameObject go in coinsGOArray)
        {
            go.SetActive(true);
        }
        timerText.enabled = false;
        coinsText.enabled = true;
        coinsGO.SetActive(true);
        InstantiateCharacter();
    }

    private void SpeedrunGameSetup()
    {
        isSpeedrun = true;
        timerText.enabled = true;
        coinsText.enabled = false;
        coinsGO.SetActive(false);
        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        if (isBob)
        {
            BOB = Instantiate(bobGO, new Vector3(20.42f, 92.35f, 0f), bobGO.transform.rotation);
        }
        else if (isJim)
        {
            JIM = Instantiate(jimGO, new Vector3(20.42f, 92.35f, 0f), bobGO.transform.rotation);
        }
        else if (isSuzy)
        {
            SUZY = Instantiate(suzyGO, new Vector3(20.42f, 92.35f, 0f), bobGO.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeedrun)
        {
            RunTimer(); //Abstraction
        }
    }

    private void RunTimer()
    {
        timer += Time.deltaTime;
        timerText.text = "Timer: " + timer.ToString("0.0");
    }

    public void GameFinished()
    {
        isSpeedrun = false;
        isNormalGame = false;
        if (isNormalGame)
        {
            if (m_coins == 5)
            {
                finishedText.text = "You got all the coins!\nWell done!";
            }
            else
            {
                finishedText.text = $"You got {m_coins} / 5 coins";
            }

            finishedObjectsGO.SetActive(true);
            speedrunObjectsGO.SetActive(false);
            highscoreTableObjectsGO.SetActive(false);
        }
        else if (isSpeedrun)
        {
            finishedObjectsGO.SetActive(false);
            speedrunObjectsGO.SetActive(true);
            highscoreTableObjectsGO.SetActive(false);
        }
    }

    public void SetupHighscores()
    {
        if (timer < timePlayer1)
        {
            currentPlayerRankingText.text = "1)";
            currentPlayerNameText.text = enteredName.text;
            timeCurrentPlayerText.text = timer.ToString("0.0");

            //Moves player 1 stats down and player 2 stats down and replaces 1 player stats with the current stats
            player2Text.text = player1Text.text;
            timePlayer2Text.text = timePlayer1Text.text;

            player3Text.text = player2Text.text;
            timePlayer3Text.text = timePlayer2Text.text;

            player1Text.text = currentPlayerNameText.text;
            timePlayer1Text.text = timeCurrentPlayerText.text;
        }
        else if (timer < timePlayer2)
        {
            currentPlayerRankingText.text = "2)";
            currentPlayerNameText.text = enteredName.text;
            timeCurrentPlayerText.text = timer.ToString("0.0");

            //Moves player 2 stats down and replaces it with the current stats
            player3Text.text = player2Text.text;
            timePlayer3Text.text = timePlayer2Text.text;

            player2Text.text = currentPlayerNameText.text;
            timePlayer2Text.text = timeCurrentPlayerText.text;
        }
        else if (timer < timePlayer3)
        {
            currentPlayerRankingText.text = "3)";
            currentPlayerNameText.text = enteredName.text;
            timeCurrentPlayerText.text = timer.ToString("0.0");

            player3Text.text = currentPlayerNameText.text;
            timePlayer3Text.text = timeCurrentPlayerText.text;
        }
        else
        {
            currentPlayerRankingText.text = "4+";
            currentPlayerNameText.text = enteredName.text;
            timeCurrentPlayerText.text = timer.ToString("0.0");
        }
        SaveManager.Instance.Save();
    }

    public void ResetAllHighscores()
    {
        timePlayer1 = 0;
        timePlayer2 = 0;
        timePlayer3 = 0;

        player1Text.text = "Player";
        player2Text.text = "Player";
        player3Text.text = "Player";
    }

    public void MainMenu()
    {
        DestroyPlayer();
        SceneManager.LoadScene(0);
    }

    private void DestroyPlayer()
    {
        if (isBob)
        {
            Destroy(BOB);
        }
        else if (isJim)
        {
            Destroy(JIM);
        }
        else if (isSuzy)
        {
            Destroy(SUZY);
        }
    }

    public void PlayAgain()
    {
        DestroyPlayer();
        if (isNormalGame)
        {
            NormalGameSetup();
        }
        else if (isSpeedrun)
        {
            SpeedrunGameSetup();
        }
    }
}
