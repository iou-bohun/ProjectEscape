using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            Debug.Log("clear");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            Debug.Log("Unclear");
        }
    }
}
