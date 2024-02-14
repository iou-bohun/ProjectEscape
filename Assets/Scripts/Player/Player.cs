using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "BedRoom":
                Debug.Log("트리거 작동");
                EventManager.I.CallIBedRoomEvent();
                break;
            case "LivingRoom":
                break;
            case "Corridor":
                EventManager.I.CallCorridorEvent();
                break;
            case "BathRoom":
                break;
        }
        
     }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "BedRoom":
                Debug.Log("트리거 작동");
                EventManager.I.CallIBedRoomEvent();
                break;
            case "LivingRoom":
                break;
            case "Corridor":
                LightManager.instance.CallCorridorLight();
                break;
            case "BathRoom":
                break;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "BedRoom":
                break;
            case "LivingRoom":
                break;
            case "Corridor":
                LightManager.instance.CallCorridorOffTimer();
                break;
            case "BathRoom":
                break;
        }
    }
}
