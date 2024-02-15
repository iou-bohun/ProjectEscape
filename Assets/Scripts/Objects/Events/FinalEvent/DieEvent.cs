using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DieEvent : MonoBehaviour
{
    public Transform player;
    public GameObject bloodBox;
    private bool isSceneStart;

    private void Awake()
    {

    }

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<Transform>();
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
                                StartCoroutine(DieforSecond());
                                break;
                            case "DownDoor":
                                LightManager.instance.CallBlackOutEvent();
                                LightManager.instance.isBlackOutEvent = true;
                                StartCoroutine(DieforSecond());
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

    IEnumerator DieforSecond()
    {
        bloodBox.SetActive(true);
        yield return new WaitForSeconds(3);
        GameManager.Instance.GameOver();
    }


}
