using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear1st : MonoBehaviour
{
    private bool isChecked = false;
    private void Start()
    {
        EventManager.I.corridorEvent += CheckClear;
    }

    public void CheckClear()
    {
        if(isChecked)
        {
            return;
        }
        isChecked = true;
        GameManager.Instance.Clear();
    }
}
