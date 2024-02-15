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

    private void LateUpdate()
    {
        if (isSceneStart && !LightManager.instance.isBlackOutClear)
        {
            sceneTime += Time.deltaTime;
            if(sceneTime > 10&& sceneTime<11)
            {
                LightManager.instance.isBlackOutEvent = true;
                LightManager.instance.CallBlackOutEvent();
            }
            if (sceneTime > 50&&!LightManager.instance.isPlayerDie)
            {
                Debug.Log("¿Ø¥Ÿ»Ò");
                LightManager.instance.isPlayerDie = true;
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
                                LightManager.instance.isBlackOutEvent = true;
                                LightManager.instance.CallBlackOutEvent();
                                break;
                            case "SloveBlackOut":
                                Debug.Log("SloveBlackOut");
                                LightManager.instance.isBlackOutEvent = false;
                                LightManager.instance.isBlackOutClear = true;
                                LightManager.instance.CallLivingRoomLight();
                                LightManager.instance.CallLivingRoomLight2();
                                LightManager.instance.CallCorridorOffTimer();
                                StartCoroutine(SloveBlackOut());
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
