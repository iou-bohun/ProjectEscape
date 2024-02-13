using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborDoorEvent : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.corridorEvent += CloseDoor;
    }
    public void CloseDoor()
    {
        _animator.SetTrigger("Close");
    }
}
