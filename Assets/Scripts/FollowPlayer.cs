using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0f, -0.5f, -10f);

    PersistentData persistentData;

    // Start is called before the first frame update
    void Start()
    {
        persistentData = GameObject.Find("PersistentData").GetComponent<PersistentData>();
    }

    public void PlayerReference()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (persistentData.isNormalGame || persistentData.isSpeedrun)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
