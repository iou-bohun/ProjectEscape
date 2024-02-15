using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public static LightManager instance;
    public event Action OnLivingRoom;
    public event Action OnLivingRoom2;
    public event Action OnBedRoom;
    public event Action OnBathRoom;
    public event Action OnCorridorLight;
    public event Action OnCorridorOffTimer;
    public event Action OnBlackOutEvent;
    public bool isBlackOutEvent;
    public bool isBlackOutClear;
    public bool isPlayerDie;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        isBlackOutEvent = false;
    }
    public void CallLivingRoomLight()
    {
        if (!isBlackOutEvent)
            OnLivingRoom?.Invoke();
    }
    public void CallLivingRoomLight2()
    {
        if (!isBlackOutEvent)
            OnLivingRoom2?.Invoke();
    }
    public void CallBedRoomLight()
    {
        if (!isBlackOutEvent)
            OnBedRoom?.Invoke();
    }
    public void CallBathRoomLight()
    {
        if (!isBlackOutEvent)
            OnBathRoom?.Invoke();
    }
    public void CallCorridorLight()
    {
        if(!isBlackOutEvent)
        OnCorridorLight?.Invoke();
    }
    public void CallCorridorOffTimer()
    {
        OnCorridorOffTimer?.Invoke();
    }
    public void CallBlackOutEvent()
    {
        if (isBlackOutEvent)
            OnBlackOutEvent?.Invoke();
    }


}
