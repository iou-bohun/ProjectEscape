using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingEvent : MonoBehaviour
{
    private Rigidbody _rigid;
    private bool isDropped;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>(); 

    }

    private void Start()
    {
        isDropped = false;
        EventManager.I.bedRoomEvent += DropItem;
    }

    private void DropItem()
    {
        if (isDropped) { return; }
        _rigid.useGravity = true;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.otherMovement, this.transform.position);
        isDropped = true;
    }
}
