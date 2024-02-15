using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            GameManager.Instance.Clear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "주민 설문조사[작성]")
        {
            GameManager.Instance.UnClear();
        }
    }
}
