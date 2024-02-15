using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
        SceneManager.LoadScene(PlayerPrefs.GetInt("stage" + "stEventScene"));
        if (PlayerPrefs.GetInt("stage" + "stEventScene") != 1)
        {
            Instantiate(Resources.Load("Donts"));
        }
        //switch (PlayerPrefs.GetInt("ClearData"))
        //{
        //    case 1:
        //        SceneManager.LoadScene("2ndEventScene");
        //        break;
        //    case 2:
        //        SceneManager.LoadScene("3rdEventScene");
        //        break;
        //    case 3:
        //        SceneManager.LoadScene("4thEventScene");
        //        break;
        //    case 4:
        //        SceneManager.LoadScene("5thEventScene");
        //        break;
        //    case 5:
        //        SceneManager.LoadScene("6thEventScene");
        //        break;
        //    default:
        //        haveNoSaveData.SetActive(true);
        //        break;
        //}
    }

    public void OnConfirmBtn()
    {
        haveNoSaveData.SetActive(false);
    }
}
