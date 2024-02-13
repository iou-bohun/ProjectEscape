using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEvent : MonoBehaviour
{
    [SerializeField] GameObject player;
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
        animator.SetBool("ShakeWindow", true);
    }

}
