using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightBathRoom : LightObject
{
    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {
        LightManager.instance.OnBathRoom += OnOffLight;
    }
}
