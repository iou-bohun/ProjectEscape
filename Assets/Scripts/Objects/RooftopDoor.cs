using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RooftopDoor : MonoBehaviour
{
    public Animator openandclose;
    public bool open;
    public Transform Player;
    public GameObject Password;
    public InputField passwordInput;

    private void Awake()
    {
        Player = GameManager.Instance.player.transform;
    }
    void Start()
    {
        open = false;
    }

    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 5)
                {
                    if (open == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Password.gameObject.SetActive(true);
                            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;

                        }
                    }
                    else
                    {
                        if (open == true)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(closing());
                            }
                        }

                    }

                }
            }

        }

    }
    public void OnESCButton()
    {
        Password.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }

    public void OnEnterButton()
    {
        if (passwordInput.text != "2859")
            return;
        Password.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
        StartCoroutine(opening());
    }



    IEnumerator opening()
    {
        print("you are opening the door");
        openandclose.Play("Opening");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.doorOpened, this.transform.position);
        EventManager.I.flashCount = 0;
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.doorClosed, this.transform.position);
        open = false;
        yield return new WaitForSeconds(.5f);
    }


}

