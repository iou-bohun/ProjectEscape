using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightCorridor : LightObject
{
    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {
        LightManager.instance.OnCorridorLight += OnLight;
        LightManager.instance.OnCorridorOffTimer += OffLight;
    }
}
