using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private Light _light;
    public GameObject _glove;
    private Renderer _glovematerial;
    bool isTurnOnLight;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _glovematerial = _glove.GetComponent<Renderer>();
        isTurnOnLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
