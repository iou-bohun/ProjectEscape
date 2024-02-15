using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    bool a = true;
    private void Update()
    {
        if (a)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.i.CheckInven("º¼Ææ"))
                {
                    PlayerController.instance.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Instantiate(Resources.Load("paper"), FindObjectOfType<Canvas>().transform);
                    a = false;
                }
            }
        }
    }
}
