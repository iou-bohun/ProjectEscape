using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightBedRoom : LightObject
{
    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {
        LightManager.instance.OnBedRoom += OnOffLight;
    }
}
