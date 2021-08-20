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
        public string player1Text;
        public string player2Text;
        public string player3Text;

        public float timePlayer1;
        public float timePlayer2;
        public float timePlayer3;

        public string timePlayer1Text;
        public string timePlayer2Text;
        public string timePlayer3Text;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.player1Text = GameManager.Instance.player1Text.text;
        data.player2Text = GameManager.Instance.player2Text.text;
        data.player3Text = GameManager.Instance.player3Text.text;

        data.timePlayer1 = GameManager.Instance.timePlayer1;
        data.timePlayer2 = GameManager.Instance.timePlayer2;
        data.timePlayer3 = GameManager.Instance.timePlayer3;

        data.timePlayer1Text = GameManager.Instance.timePlayer1Text.text;
        data.timePlayer2Text = GameManager.Instance.timePlayer2Text.text;
        data.timePlayer3Text = GameManager.Instance.timePlayer3Text.text;

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
            GameManager.Instance.player1Text.text = data.player1Text;
            GameManager.Instance.player2Text.text = data.player2Text;
            GameManager.Instance.player3Text.text = data.player3Text;

            GameManager.Instance.timePlayer1 = data.timePlayer1;
            GameManager.Instance.timePlayer2 = data.timePlayer2;
            GameManager.Instance.timePlayer3 = data.timePlayer3;

            GameManager.Instance.timePlayer1Text.text = data.timePlayer1Text;
            GameManager.Instance.timePlayer2Text.text = data.timePlayer2Text;
            GameManager.Instance.timePlayer3Text.text = data.timePlayer3Text;
        }
    }
}
