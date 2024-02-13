using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager I;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Action bedRoomEvent;
    public Action corridorEvent;

    public void CallIBedRoomEvent()
    {
       bedRoomEvent?.Invoke();
    }

    public void CallCorridorEvent()
    {
        corridorEvent?.Invoke();
    }
}
