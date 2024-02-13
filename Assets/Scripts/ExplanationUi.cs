using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ExplanationUi : MonoBehaviour
{
    [SerializeField] Text ExplantText;
    [SerializeField] float distance;
    Camera _camera;
    ItemObject LookItem;
    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,distance,LayerMask.GetMask("Item")))
        {
            if (hit.collider.gameObject != LookItem)
            {
                LookItem = hit.collider.gameObject.GetComponent<ItemObject>();
                ExplantText.gameObject.SetActive(true);
                ExplantText.text = LookItem.ItemName();
            }
        }
        else
        {
            LookItem = null;
            ExplantText.gameObject.SetActive(false);
        }
    }
    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && LookItem != null)
        {
            LookItem.Put();
            LookItem = null;
            ExplantText.gameObject.SetActive(false);
        }
    }
}
