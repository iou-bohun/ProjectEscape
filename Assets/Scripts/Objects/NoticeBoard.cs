using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoard : MonoBehaviour
{
    [SerializeField] private GameObject[] _paper;
    [SerializeField] private GameObject _completePaper;
    [SerializeField] private GameObject _fourPaper;
    [SerializeField] private ItemData[] _paperData;

    public GameObject[] onBoardPaper;
    public GameObject player;
    private InventoryInput invenInput;

    private void Awake()
    {
        invenInput = player.GetComponent<InventoryInput>();
    }
    private void Start()
    {
        for (int i = 0; i < onBoardPaper.Length; i++)
        {
            onBoardPaper[i].SetActive(false);
        }
    }
    public void CheckHandItem()
    {

        for (int i = 0; i < _paper.Length; i++)
        {
            if (Inventory.i.HandItem.tag == _paper[i].tag)
            {
                CollectPaper(i);
                break;
            }
        }

    }

    private void CollectPaper(int index)
    {
        int currentIndex = invenInput.currentIndex;

        onBoardPaper[index].gameObject.SetActive(true);
        Inventory.i.DeleteItem(currentIndex);
        CompletePaper();
    }


    private void OnMouseOver()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist > 5)
            {
                if (Input.GetMouseButtonDown(0) && Inventory.i.HandItem != null)
                {
                    CheckHandItem();
                }
            }
        }
    }

    private void CompletePaper()
    {
        if (onBoardPaper[0].activeInHierarchy && onBoardPaper[1].activeInHierarchy && onBoardPaper[2].activeInHierarchy && onBoardPaper[3].activeInHierarchy)
        {
            _fourPaper.SetActive(false);
            _completePaper.SetActive(true);
        }
    }

}
