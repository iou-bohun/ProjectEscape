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
                Debug.Log("Ʈ���� �۵�");
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
}
