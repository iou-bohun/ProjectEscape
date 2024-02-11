using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum Rooms
{
    BedRoom=0,
    LivingRoom,
    BathRoom,
    Corridor,
}

public class Player : MonoBehaviour
{
    public Dictionary<Rooms, bool> PlayerPosition = new Dictionary<Rooms, bool>();

    private void Start()
    {
        PlayerPosition.Clear();
        PlayerPosition.Add(Rooms.BedRoom, false);
        PlayerPosition.Add(Rooms.LivingRoom, false);
        PlayerPosition.Add(Rooms.Corridor, false);
        PlayerPosition.Add(Rooms.BathRoom, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "BedRoom":
                ResetPlayerPosition(Rooms.BedRoom);
                break;
            case "LivingRoom":
                ResetPlayerPosition(Rooms.LivingRoom);
                break;
            case "Corridor":
                ResetPlayerPosition(Rooms.Corridor);
                break;
            case "BathRoom":
                ResetPlayerPosition(Rooms.BathRoom);
                break;
        }
        foreach (KeyValuePair<Rooms, bool> room in PlayerPosition)
        {
            if(room.Value == true)
            {
                Debug.Log("프레이어는 현제 "+(room.Key));
            }
        }

    }
    private void ResetPlayerPosition(Rooms room)
    {
        PlayerPosition.Keys.ToList().ForEach(key =>
        {
            PlayerPosition[key] = false;
        });
        PlayerPosition[room] = true;
    }
}
