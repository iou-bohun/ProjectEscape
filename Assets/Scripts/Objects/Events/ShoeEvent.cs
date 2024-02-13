using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeEvent : MonoBehaviour
{
    [SerializeField] private Transform eventPosition;

    private bool isMoved = false;

    private void Start()
    {
        EventManager.I.bedRoomEvent+=MoveObject;
    }

    private void MoveObject()
    {
        
        if (!isMoved)
        {
            isMoved = true;
            transform.position = eventPosition.transform.position;
        }
    }
}
