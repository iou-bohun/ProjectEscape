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
    public Light _reflexlight;
    private Renderer _glovematerial;
    private bool isTurnOnLight;
    private float targetIntensity;
    WaitForSeconds sensorTime;
    WaitForSeconds flickerTime;

    protected virtual void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _glovematerial = _glove.GetComponent<Renderer>();
        isTurnOnLight = true;
        sensorTime = new WaitForSeconds(3f);
        targetIntensity = 0.6f;
        flickerTime = new WaitForSeconds(0.5f);

    }


    public void OnOffLight()
    {
        if (_light != null)
        {
            if (isTurnOnLight)
            {
                if(_reflexlight != null) { _reflexlight.enabled = false; }
                _light.enabled = false;
                isTurnOnLight = false;
                _glovematerial.material.DisableKeyword("_EMISSION");
            }
            else
            {
                if (_reflexlight != null) { _reflexlight.enabled = true; }
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
            _light.intensity = 1;
            if (!isTurnOnLight)
            {
                _light.enabled = true;
                isTurnOnLight = true;
                _glovematerial.material.EnableKeyword("_EMISSION");
                AudioManager.instance.PlayOneShot(FMODEvents.instance.lampOnOff, this.transform.position);
            }
        }
    }

    public void OffLight()
    {
        if (_light != null)
        {
            if (isTurnOnLight)
            {
                if (_reflexlight != null) { _reflexlight.enabled = false; }
                _light.enabled = false;
                isTurnOnLight = false;
                _glovematerial.material.DisableKeyword("_EMISSION");
            }
        }

    }
    public void BlackOutCorridor()
    {
        StartCoroutine(BlackOut());
    }
    public void OffCorridor()
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

    IEnumerator BlackOut() 
    {
        while (true)
        {
            if (LightManager.instance.isBlackOutEvent && _light != null) 
            {
                if (_light.intensity > 0)
                {
                    _light.intensity = UnityEngine.Random.Range(0f, targetIntensity);
                    targetIntensity -= UnityEngine.Random.Range(-0.005f, 0.01f);
                    yield return flickerTime;
                }
                else
                {
                    LightManager.instance.CallCorridorOffTimer();
                    yield return flickerTime;
                }
                
            }
            else
            {
                yield return null;
            }
        }
    }
}
