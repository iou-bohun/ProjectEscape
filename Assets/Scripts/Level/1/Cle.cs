using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            GameManager.Instance.Clear();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            GameManager.Instance.UnClear();
        }
    }
}
