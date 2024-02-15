using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightLivingRoom1 : LightObject
{

    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {
        LightManager.instance.OnBlackOutEvent += OffLight;
        LightManager.instance.OnLivingRoom += OnOffLight;
    }



}
