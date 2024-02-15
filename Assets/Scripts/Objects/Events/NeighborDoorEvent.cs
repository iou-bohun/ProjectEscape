using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborDoorEvent : MonoBehaviour
{
    Animator _animator;
    private bool _isClosed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.corridorEvent += CloseDoor;
        _isClosed = false;
    }
    public void CloseDoor()
    {
        if(_isClosed) return;
        _animator.SetTrigger("Close");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.doorClosed, this.transform.position);
        _isClosed = true;
    }
}
