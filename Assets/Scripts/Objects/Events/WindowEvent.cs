using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEvent : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.bedRoomEvent += ShakeWindow;
    }

    public void ShakeWindow()
    {
        animator.SetBool("Shake", true);
    }

}
