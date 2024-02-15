using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnLoopEvent;
    public GameObject player;
    public GameObject DiePanel;
    WaitForSeconds waitSceneTime;
    public GameObject completePaper;

    private void Awake()
    {
        if (Instance == null)
        Instance = this;
    }
    private void Start()
    {
        waitSceneTime = new WaitForSeconds(3);
        EventManager.I.playerDieEvent += GameOver;
    }


    void Update()
    {
        LoopPlayer();
    }

    private void LoopPlayer()
    {
        if (player.transform.position.z > 14)
        {
            if (player.transform.position.x >= 15.5f && player.transform.position.y >= 4.2f)
            {
                if (completePaper.activeInHierarchy)
                    return;
                player.transform.position = new Vector3(player.transform.position.x, -3.65f, player.transform.position.z);
                CallLoopEvent();

            }
            else if (player.transform.position.x <= 15.4f && player.transform.position.y <= -3.65f) 
            {
                player.transform.position = new Vector3(player.transform.position.x, 4.3f, player.transform.position.z); 
                CallLoopEvent();
            }
        }

    }
    private void CallLoopEvent()
    {
        OnLoopEvent?.Invoke();
    }

    public void GameOver()
    {
        StartCoroutine(PlayerDie());       
    }

    IEnumerator PlayerDie()
    {
        DiePanel.SetActive(true);
        yield return waitSceneTime;
        SceneManager.LoadScene(SceneManager.loadedSceneCount);
    }
}
