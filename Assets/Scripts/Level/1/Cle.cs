using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            GameManager.Instance.Clear();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            GameManager.Instance.UnClear();
        }
    }
}
