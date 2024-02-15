using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            GameManager.Instance.Clear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemObjects>()?.item.disPlayName == "�ֹ� ��������[�ۼ�]")
        {
            GameManager.Instance.UnClear();
        }
    }
}
