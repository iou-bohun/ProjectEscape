using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlackOutEvent : MonoBehaviour
{
    public Transform player;
    private Animator blackOut;
    private bool isSceneStart;
    float sceneTime;

    private void Awake()
    {
        blackOut = GetComponent<Animator> ();
        isSceneStart = true;
        sceneTime = 0;
    }

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        if (isSceneStart && !LightManager.instance.isBlackOutClear)
        {
            sceneTime += Time.deltaTime;
            if(sceneTime > 30&& sceneTime<31)
            {
                LightManager.instance.CallBlackOutEvent();
                LightManager.instance.isBlackOutEvent = true;

            }
            if (sceneTime > 60&&!LightManager.instance.isPlayerDie)
            {
                Debug.Log("������");
                LightManager.instance.isPlayerDie = true;
                EventManager.I.CallplayerDieEvent();
            }
        }
    }

    void OnMouseOver()
    {
        {
            if (player)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                if (dist < 5)
                {
                    if (Input.GetMouseButtonDown(0)&&!LightManager.instance.isBlackOutClear)
                    {
                        switch (gameObject.name)
                        {
                            case "BlackOut":
                                LightManager.instance.CallBlackOutEvent();
                                LightManager.instance.isBlackOutEvent = true;

                                break;
                            case "SloveBlackOut":
                                if (LightManager.instance.isBlackOutEvent&&EventManager.I.handFlash)
                                {
                                    Debug.Log("SloveBlackOut");
                                    LightManager.instance.isBlackOutEvent = false;
                                    LightManager.instance.isBlackOutClear = true;
                                    LightManager.instance.CallLivingRoomLight();
                                    LightManager.instance.CallLivingRoomLight2();
                                    LightManager.instance.CallCorridorOffTimer();
                                    GameManager.Instance.Clear();
                                    StartCoroutine(SloveBlackOut());
                                    break;
                                }
                                else
                                    Debug.Log("������ �Ͼ �� �������� Ŭ������");
                                break;
                            default:
                                Debug.Log("default");
                                break;
                        }

                    }
                }
            }

        }
    }

    IEnumerator SloveBlackOut()
    {
        print("you slove BlackOut Quiz");
        blackOut.Play("BlackOutAnimation");
        yield return new WaitForSeconds(.5f);
    }

}
