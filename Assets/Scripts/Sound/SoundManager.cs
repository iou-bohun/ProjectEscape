using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // SoundManager에선 3D가 적용되지 않는 소리(BGM, 일부SFX)만 관리합니다.
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        if (GameObject.FindWithTag(sfxName) == null)
        {
            GameObject go = new GameObject(sfxName + "Sound");
            go.tag = sfxName;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(go, clip.length);
        }
    }


}
