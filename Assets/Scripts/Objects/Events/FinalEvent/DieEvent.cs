using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DieEvent : MonoBehaviour
{
    public Transform player;
    public GameObject[] blood;
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
                                RuntimeManager.StudioSystem.setParameterByName("WindEnd", 0.1f);
                                AudioManager.instance.PlayOneShot(FMODEvents.instance.whenLightsOut, player.transform.position);
                                StartCoroutine(DieforSecond());
                                break;
                            case "DownDoor":
                                LightManager.instance.CallBlackOutEvent();
                                LightManager.instance.isBlackOutEvent = true;
                                RuntimeManager.StudioSystem.setParameterByName("WindEnd", 0.1f);
                                AudioManager.instance.PlayOneShot(FMODEvents.instance.whenLightsOut, player.transform.position);
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
            for (int i = 0; i < 16; i++)
            {
                blood[i].SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(3);
            RuntimeManager.StudioSystem.setParameterByName("WindEnd", 1.0f);
            GameManager.Instance.GameOver();
    }


}
