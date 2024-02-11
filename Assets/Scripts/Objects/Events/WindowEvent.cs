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


    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            animator.SetBool("IsShaking", true);
        }
        else
        {
            animator.SetBool("IsShaking", false);
        }
    }
}
