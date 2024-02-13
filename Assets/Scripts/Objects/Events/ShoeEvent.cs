using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeEvent : MonoBehaviour
{
    [SerializeField] private Transform originPosition;
    [SerializeField] private Transform eventPosition;

    private bool isMoved = false;

    private void Start()
    {
        EventManager.I.bedRoomEvent+=MoveObject;
    }

    private void MoveObject()
    {
        Debug.Log("신발 이동");
    }
}
