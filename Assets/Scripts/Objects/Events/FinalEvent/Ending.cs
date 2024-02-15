using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject endPanel;
    WaitForSeconds ending;

    private void Awake()
    {
        ending = new WaitForSeconds(3);
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (EventManager.I.flashCount == 3)
                    EndingEvent();
                break;
        }

    }

    public void EndingEvent()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return ending;
        endPanel.SetActive(true);
        yield return ending;
        SceneManager.LoadScene("Title");


    }


}
