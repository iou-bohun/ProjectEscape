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
        if (player.transform.position.y > 4.85f) player.transform.position = new Vector3(player.transform.position.x, -1.4f, player.transform.position.z);
        else if (player.transform.position.y < -1.45) player.transform.position = new Vector3(player.transform.position.x, 4.85f, player.transform.position.z);
    }
}
