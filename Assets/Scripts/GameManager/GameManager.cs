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
    int stage;

    [Header("boolCheck")]
    public bool isCanGoRoofTop = false;
    public bool isClearStage = false;

    private bool isOnce;

    private void Awake()
    {
        player = GameObject.Find("Player");
        if (Instance == null)
        Instance = this;
    }
    private void Start()
    {
        
        waitSceneTime = new WaitForSeconds(3);
        EventManager.I.playerDieEvent += GameOver;
        isOnce = true;
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
                if(isCanGoRoofTop)
                {
                    return;
                }
                if (stage + "stEventScene" == SceneManager.GetActiveScene().name)
                {
                    player.transform.position = new Vector3(player.transform.position.x, -3.65f, player.transform.position.z);
                    IsFirstLoop();
                    CallLoopEvent();
                }
                else if(stage + "stEventScene" != SceneManager.GetActiveScene().name)
                {
                    Inventory.i.Clear();
                    SceneManager.LoadScene(stage + "stEventScene");
                }

            }
            else if (player.transform.position.x <= 15.4f && player.transform.position.y <= -3.65f) 
            {
                if (stage + "stEventScene" == SceneManager.GetActiveScene().name)
                {
                    player.transform.position = new Vector3(player.transform.position.x, 4.3f, player.transform.position.z);
                    IsFirstLoop();
                    CallLoopEvent();
                }
                else if (stage + "stEventScene" != SceneManager.GetActiveScene().name)
                {
                    Inventory.i.Clear();
                    SceneManager.LoadScene(stage + "stEventScene");
                }
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

    public void IsFirstLoop()
    {
        if (isOnce)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.firstLooped, player.transform.position);
            isOnce = false;
        }
    }

    IEnumerator PlayerDie()
    {
        DiePanel.SetActive(true);
        yield return waitSceneTime;
        DiePanel.SetActive(false);
        Inventory.i.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Clear()
    {
        stage++;
        PlayerPrefs.SetInt("stage",stage);
    }
    public void UnClear()
    {
        stage--;
        PlayerPrefs.SetInt("stage", stage);
    }
}
