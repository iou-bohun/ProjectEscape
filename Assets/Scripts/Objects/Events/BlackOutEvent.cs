using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlackOutEvent : MonoBehaviour
{
    public Transform player;
    private Animator blackOut;

    private void Awake()
    {
        blackOut = GetComponent<Animator> ();
    }

    void OnMouseOver()
    {
        {
            if (player)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                if (dist < 5)
                {
                    if (Input.GetMouseButtonDown(0))
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
                                LightManager.instance.CallLivingRoomLight();
                                LightManager.instance.CallLivingRoomLight2();
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
