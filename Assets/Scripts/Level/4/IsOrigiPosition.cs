using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOrigiPosition : MonoBehaviour
{
    public bool isOrigin = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            isOrigin = true;
        }
    }
}
