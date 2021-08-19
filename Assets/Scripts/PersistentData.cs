using UnityEngine;

public class PersistentData : MonoBehaviour
{
    //Bools
    public bool isBob;
    public bool isJim;
    public bool isSuzy;

    public bool isNormalGame;
    public bool isSpeedrun;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
