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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void CallLivingRoomLight()
    {
        OnLivingRoom?.Invoke();
    }
    public void CallLivingRoomLight2()
    {
        OnLivingRoom2?.Invoke();
    }
    public void CallBedRoomLight()
    {
        OnBedRoom?.Invoke();
    }
    public void CallBathRoomLight()
    {
        OnBathRoom?.Invoke();
    }
    public void CallCorridorLight()
    {
        OnCorridorLight?.Invoke();
    }
    public void CallCorridorOffTimer()
    {
        OnCorridorOffTimer?.Invoke();
    }


}
