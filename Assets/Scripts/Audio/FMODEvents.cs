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
