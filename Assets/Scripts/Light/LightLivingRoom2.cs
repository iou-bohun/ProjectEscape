using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightLivingRoom2 : LightObject
{
    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {
        LightManager.instance.OnLivingRoom2 += OnOffLight;
    }
}
