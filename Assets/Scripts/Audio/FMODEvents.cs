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

    public static FMODEvents instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Scene�� ��� �ϳ��� FMODEvents�� �����ϴ� �� Ȯ���ϼ���.");
        }
        instance = this;
    }
}
