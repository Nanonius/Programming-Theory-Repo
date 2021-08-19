using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

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
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        //Gamemanager variables that should be saved
        public TextMeshProUGUI player1Text;
        public TextMeshProUGUI player2Text;
        public TextMeshProUGUI player3Text;

        public float timePlayer1;
        public float timePlayer2;
        public float timePlayer3;

        public TextMeshProUGUI timePlayer1Text;
        public TextMeshProUGUI timePlayer2Text;
        public TextMeshProUGUI timePlayer3Text;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.player1Text = GameManager.Instance.player1Text;
        data.player2Text = GameManager.Instance.player2Text;
        data.player3Text = GameManager.Instance.player3Text;

        data.timePlayer1 = GameManager.Instance.timePlayer1;
        data.timePlayer2 = GameManager.Instance.timePlayer2;
        data.timePlayer3 = GameManager.Instance.timePlayer3;

        data.timePlayer1Text = GameManager.Instance.timePlayer1Text;
        data.timePlayer2Text = GameManager.Instance.timePlayer2Text;
        data.timePlayer3Text = GameManager.Instance.timePlayer3Text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.Instance.player1Text = data.player1Text;
            GameManager.Instance.player2Text = data.player2Text;
            GameManager.Instance.player3Text = data.player3Text;

            GameManager.Instance.timePlayer1 = data.timePlayer1;
            GameManager.Instance.timePlayer2 = data.timePlayer2;
            GameManager.Instance.timePlayer3 = data.timePlayer3;

            GameManager.Instance.timePlayer1Text = data.timePlayer1Text;
            GameManager.Instance.timePlayer2Text = data.timePlayer2Text;
            GameManager.Instance.timePlayer3Text = data.timePlayer3Text;
        }
    }
}
