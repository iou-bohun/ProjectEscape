using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMunu : MonoBehaviour
{
    public GameObject haveNoSaveData;

    public void OnStartBtn()
    {
        SceneManager.LoadScene("1stEventScene");
    }

    public void OnLoadBtn()
    {
        switch (PlayerPrefs.GetInt("ClearData"))
        {
            case 1:
                SceneManager.LoadScene("2ndEventScene");
                break;
            case 2:
                SceneManager.LoadScene("3rdEventScene");
                break;
            case 3:
                SceneManager.LoadScene("5thEventScene");
                break;
            case 4:
                SceneManager.LoadScene("6thEvnetScene");
                break;
            case 5:
                SceneManager.LoadScene("EndingScene");
                break;
            default:
                haveNoSaveData.SetActive(true);
                break;
        }
    }

    public void OnConfirmBtn()
    {
        haveNoSaveData.SetActive(false);
    }
}
