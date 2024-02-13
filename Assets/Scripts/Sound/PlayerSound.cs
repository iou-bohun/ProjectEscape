using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] walkMetalV1;


    IEnumerator LoopWalkSFX()
    {
        while (true)
        {
            float wait = SFXWalk();
            yield return new WaitForSeconds(wait);
            Debug.Log("LoopWalkSFX 실행 중입니다.");
        }
    }

    public float SFXWalk()
    {
        int rand = Random.Range(0, walkMetalV1.Length); // 소스 랜덤 뽑기
        SoundManager.instance.SFXPlay("WalkSFX" + (rand + 1), walkMetalV1[rand]);
        return walkMetalV1[rand].length;
    }

    public void OnWalk()
    {
        StartCoroutine("LoopWalkSFX");
    }

    public void OffWalk()
    {
        StopCoroutine("LoopWalkSFX");
    }
}
