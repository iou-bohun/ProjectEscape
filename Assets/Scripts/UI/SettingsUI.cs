using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsUI;

    private bool isTabOn;

    private void Awake()
    {
        isTabOn = false;
        settingsUI.SetActive(false);
    }

    public void OnTabInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!isTabOn)
            {
                settingsUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                isTabOn = true;
            }
            else
            {
                settingsUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isTabOn = false;
            }
        }
    }
}
