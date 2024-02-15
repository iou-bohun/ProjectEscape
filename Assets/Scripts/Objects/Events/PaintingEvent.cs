using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingEvent : MonoBehaviour
{
    private Rigidbody _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>(); 

    }

    private void Start()
    {
        EventManager.I.bathRoomEvent += DropItem;
    }

    private void DropItem()
    {
        _rigid.useGravity = true;
    }
}
