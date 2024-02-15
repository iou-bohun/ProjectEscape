using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            Debug.Log("clear");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            Debug.Log("Unclear");
        }
    }
}
