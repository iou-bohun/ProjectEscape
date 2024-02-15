using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear4th : MonoBehaviour
{
    [SerializeField] IsOrigiPosition[] origins;
    private int clearCount =0;

   

    private void CheckClear()
    {
       for(int i = 0; i < origins.Length; i++)
        {
            if (origins[i].isOrigin == true)
            {
                clearCount++;   
            }
        }
        if (clearCount >= 3)
        {
            GameManager.Instance.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            CheckClear();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            clearCount = 0;
        }
    }
}
