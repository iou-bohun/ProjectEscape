using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private Light _light;
    public GameObject _glove;
    private Renderer _glovematerial;
    private bool isTurnOnLight;
    WaitForSeconds sensorTime;

    protected virtual void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _glovematerial = _glove.GetComponent<Renderer>();
        isTurnOnLight = true;
        sensorTime = new WaitForSeconds(3f);

    }


    public void OnOffLight()
    {
        if (_light != null)
        {
            if (isTurnOnLight)
            {
                _light.enabled = false;
                isTurnOnLight = false;
                _glovematerial.material.DisableKeyword("_EMISSION");
            }
            else
            {
                _light.enabled = true;
                isTurnOnLight = true;
                _glovematerial.material.EnableKeyword("_EMISSION");
            }
        }
    }
    public void OnLight()
    {
        if (_light != null)
        {
            if (!isTurnOnLight)
            {
                _light.enabled = true;
                isTurnOnLight = true;
                _glovematerial.material.EnableKeyword("_EMISSION");
            }
        }
    }

    public void OffLight()
    {
        StartCoroutine(OffTimer());
        
    }

    IEnumerator OffTimer()
    {
        yield return sensorTime;
        if (_light != null)
        {
            if (isTurnOnLight)
            {
                _light.enabled = false;
                isTurnOnLight = false;
                _glovematerial.material.DisableKeyword("_EMISSION");
            }
        }
    }
}
