using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.i.CheckInven("º¼Ææ"))
            {
                PlayerController.instance.enabled = false;
                Instantiate(Resources.Load("paper"),FindObjectOfType<Canvas>().transform);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
