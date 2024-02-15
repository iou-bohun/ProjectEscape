using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference footstepsWalkRock { get; private set; }
    [field: SerializeField] public EventReference footstepsRunRock { get; private set; }
    [field: SerializeField] public EventReference footstepsJumpRock { get; private set; }
    [field: SerializeField] public EventReference footstepsLandRock { get; private set; }


    [field: Header("Door SFX")]
    [field: SerializeField] public EventReference doorOpened { get; private set; }
    [field: SerializeField] public EventReference doorClosed { get; private set; }


    [field: Header("Window SFX")]
    [field: SerializeField] public EventReference windowOpened { get; private set; }
    [field: SerializeField] public EventReference windowClosed { get; private set; }
    [field: SerializeField] public EventReference windowRattle { get; private set; }


    [field: Header("TV SFX")]
    [field: SerializeField] public EventReference TVStatic { get; private set; }


    [field: Header("Light Switch SFX")]
    [field: SerializeField] public EventReference lightSwitchOnOff { get; private set; }


    [field: Header("Paper Movement SFX")]
    [field: SerializeField] public EventReference paperMovement { get; private set; }


    [field: Header("Cabinet SFX")]
    [field: SerializeField] public EventReference cabinetOpened { get; private set; }
    [field: SerializeField] public EventReference cabinetClosed { get; private set; }
    [field: SerializeField] public EventReference smallCabinetOpened { get; private set; }
    [field: SerializeField] public EventReference smallCabinetClosed { get; private set; }


    public static FMODEvents instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Scene에 적어도 하나의 FMODEvents가 존재하는 지 확인하세요.");
        }
        instance = this;
    }
}
