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
    private bool isBlackOut;
    WaitForSeconds sensorTime;
    WaitForSeconds flickerTime;

    protected virtual void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _glovematerial = _glove.GetComponent<Renderer>();
        isTurnOnLight = true;
        sensorTime = new WaitForSeconds(3f);
        flickerTime = new WaitForSeconds(0.2f);

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
        isBlackOut = LightManager.instance.isBlackOutEvent;
        if (_light != null)
        {
            _light.intensity = 1;
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
    public void BlackOutCorridor()
    {
        isBlackOut = LightManager.instance.isBlackOutEvent;
        StartCoroutine(BlackOut());

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

    IEnumerator BlackOut() 
    {
        while (true)
        {
            if (isBlackOut) 
            {
                _light.intensity = UnityEngine.Random.Range(0f,0.5f);
                yield return flickerTime;
            }
            else
            {
                yield return null;
            }
        }
    }
}
