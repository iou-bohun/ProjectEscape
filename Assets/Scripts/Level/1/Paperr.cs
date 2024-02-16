using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paperr : MonoBehaviour
{
    Button[] buttons;
    bool a = false;
    private void OnEnable()
    {
        buttons = GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(Check);
        buttons[1].onClick.AddListener(Check2);
        buttons[2].onClick.AddListener(ClosePaer);
    }
    void Check()
    {
        buttons[0].gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("asd");
        buttons[1].gameObject.GetComponent<Image>().sprite = buttons[2].gameObject.GetComponent<Image>().sprite;
        a = true;
    }
    void Check2()
    {
        buttons[1].gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("asd");
        buttons[0].gameObject.GetComponent<Image>().sprite = buttons[2].gameObject.GetComponent<Image>().sprite;
        a = true;
    }
    void ClosePaer()
    {
        if (a)
        {
            PlayerController.instance.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Inventory.i.DestroyItem("주민 설문조사");
            Inventory.i.GetItem(Resources.Load<ItemData>("envelopF"));
            Inventory.i.CatchItem(Inventory.i.CheckInven("주민 설문조사[작성]"));
            Destroy(gameObject);
        }
    }
}
