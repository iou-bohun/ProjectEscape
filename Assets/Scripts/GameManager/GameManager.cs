using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;

    private void Awake()
    {
        if (Instance == null)
        Instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        LoopPlayer();
    }

    private void LoopPlayer()
    {
        if (player.transform.position.z > 14)
        {
            if (player.transform.position.x >= 16.5f&&player.transform.position.y>=4.2f) player.transform.position = new Vector3(player.transform.position.x, -3.65f, player.transform.position.z);
            else if (player.transform.position.x <= 16.4f && player.transform.position.y <= -3.65f) player.transform.position = new Vector3(player.transform.position.x, 4.3f, player.transform.position.z);
        }

    }
}
