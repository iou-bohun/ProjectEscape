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
    public Action livingRoomEvent;
    public Action bathRoomEvent;
    public Action corridorEvent;
    public Action playerDieEvent;
    public bool handFlash;

    public void CallIBedRoomEvent()
    {
       bedRoomEvent?.Invoke();
    }

    public void CallCorridorEvent()
    {
        corridorEvent?.Invoke();
    }

    public void CallLivingRoomEvent()
    {
        livingRoomEvent?.Invoke();
    }

    public void CallBathRoomEvent()
    {
        bathRoomEvent?.Invoke();
    }
    public void CallplayerDieEvent()
    {
        playerDieEvent?.Invoke();
    }
}
