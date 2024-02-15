using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMunu : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject loadBtn;

    public void OnStartBtn()
    {
        SceneManager.LoadScene("1stEventScene");
    }

    public void OnLoadBtn()
    {
        switch (PlayerPrefs.GetInt("ClearData"))
        {
            case 1:
                SceneManager.LoadScene("");
                break;
            case 2:
                SceneManager.LoadScene("");
                break;
            case 3:
                SceneManager.LoadScene("");
                break;
            case 4:
                SceneManager.LoadScene("");
                break;
            case 5:
                SceneManager.LoadScene("");
                break;
            case 6:
                SceneManager.LoadScene("");
                break;
            default:
                break;
        }
    }
}
