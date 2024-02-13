using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] walkMetalV1;
    public AudioClip[] runMetalV1;

    public bool isRun = false; // 플레이어가 뛰는가?


    IEnumerator LoopMoveSFX()
    {
        while (true)
        {
            if (isRun == false)
            {
                float wait = SFXWalk("WalkSFX", walkMetalV1);
                yield return new WaitForSeconds(wait);
                Debug.Log("걷는 소리 반복 재생 중입니다.");
            }
            else
            {
                float wait = SFXWalk("RunSFX", runMetalV1);
                yield return new WaitForSeconds(wait);
                Debug.Log("뛰는 소리 반복 재생 중입니다.");
            }
        }
    }

    public float SFXWalk(string tag, AudioClip[] inputs)
    {
        int rand = Random.Range(0, inputs.Length); // 소스 랜덤 뽑기
        SoundManager.instance.SFXPlay(tag, inputs[rand]);
        return inputs[rand].length;
    }

    public void OnWalk()
    {
        StartCoroutine("LoopMoveSFX");
    }

    public void OnJump()
    {

    }

    public void OffWalk()
    {
        StopCoroutine("LoopMoveSFX");
    }
}
