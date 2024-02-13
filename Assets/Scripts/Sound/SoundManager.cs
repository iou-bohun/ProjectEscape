using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // SoundManager���� 3D�� ������� �ʴ� �Ҹ�(BGM, �Ϻ�SFX)�� �����մϴ�.

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
        // ���⼭ ����Ǵ� ������Ʈ�� Clear�մϴ�.
    }
}

public enum Sound
{
    Bgm,
    Sfx,
    MaxCount
}