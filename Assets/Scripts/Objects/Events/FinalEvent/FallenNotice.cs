using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FallenNotice : MonoBehaviour
{

    public Transform Player;
    public GameObject notice;


    private void Awake()
    {
        Player = GameManager.Instance.player.transform;
    }

    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 5)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        notice.gameObject.SetActive(true);
                        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;

                    }
                }
            }
        }
    }

    public void OnCloseButton()
    {
        notice.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }

}
