using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoard : MonoBehaviour
{
    [SerializeField] private GameObject[] _paper;
    [SerializeField] private ItemData[] _paperData;

    public GameObject[] onBoardPaper;
    public Transform player;


    private void Start()
    {
        for(int i = 0; i < onBoardPaper.Length; i++)
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
        onBoardPaper[index].gameObject.SetActive(true);
        Destroy(Inventory.i.HandItem.gameObject);
        Inventory.i.HandItem = null;
        for (int i = 0; i< _paperData.Length; i++)
        {
            Inventory.i.UpdateInvenUi(index , _paperData[i]);
        }
  

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

}
