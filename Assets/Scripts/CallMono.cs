using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Talk
{
    public string mono;
    public float stayTime;
    public float waitTime;
}

public class CallMono : MonoBehaviour
{
    enum Type
    {
        PickUp,Enter
    }
    public Talk[] monos;
    [SerializeField] Type type;
    private void OnDisable()
    {
        if (type == Type.PickUp)
        {
            Monologue.i?.ET(monos);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (type == Type.Enter)
        {
            if (LayerMask.GetMask("Player") == (LayerMask.GetMask("Player") | (1 << other.gameObject.layer)))
            {
                Monologue.i.ET(monos);
                Destroy(gameObject);
            }

        }
    }
}
