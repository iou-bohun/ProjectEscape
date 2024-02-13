using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // SoundManager에선 3D가 적용되지 않는 소리(BGM, 일부SFX)만 관리합니다.

    AudioSource[] audioSources = new AudioSource[(int)Sound.MaxCount];
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            // string[] soundNames = Syst
        }
    }

    public void Clear()
    {
        // 여기서 재생되던 오브젝트를 Clear합니다.
    }
}

public enum Sound
{
    Bgm,
    Sfx,
    MaxCount
}