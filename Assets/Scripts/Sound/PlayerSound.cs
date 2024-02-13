using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] walkMetalV1;
    public AudioClip[] runMetalV1;
    public AudioClip[] jumpStartMetalV1;
    public AudioClip[] jumpLandMetalV1;

    public bool isRun = false; // 플레이어가 뛰고 있는가?
    public bool isGrounded = false; // 플레이어가 바닥에 붙어 있는가?
    private bool isGroundedOnce = false;

    private void Update()
    {
        CheckGroundedOnce();
    }

    IEnumerator LoopMoveSFX() // 플레이어 움직임 관련 코루틴
    {
        while (true)
        {
            if (isGrounded) // 바닥에 붙어있고
            {
                if (isRun == false) // 걷고 있다면
                {
                    float wait = PickRandomSFX("WalkSFX", walkMetalV1);
                    yield return new WaitForSeconds(wait);
                }
                else // 뛰고 있다면
                {
                    float wait = PickRandomSFX("RunSFX", runMetalV1);
                    yield return new WaitForSeconds(wait);
                }
            }
            else
            {
                yield return null; 
            }
        }
    }

    public float PickRandomSFX(string tag, AudioClip[] inputs) // AudioClip[] 중에서 하나 뽑고 tag를 붙여 SoundManager에 전달. return값은 소리 길이.
    {
        int rand = Random.Range(0, inputs.Length); // 소스 랜덤 뽑기
        SoundManager.instance.SFXPlay(tag, inputs[rand]);
        return inputs[rand].length;
    }

    private void CheckGroundedOnce()
    {
        if (isGrounded && !isGroundedOnce)
        {
            isGroundedOnce = true;
            OnLand();
        }
        else if (!isGrounded)
        {
            isGroundedOnce = false;
        }
    }

    public void OnWalk()
    {
        StartCoroutine("LoopMoveSFX");
    }

    public void OnJump()
    {
        PickRandomSFX("JumpStartSFX", jumpStartMetalV1);
    }

    public void OnLand()
    {
        PickRandomSFX("JumpLandSFX", jumpLandMetalV1);
    }

    public void OffWalk()
    {
        StopCoroutine("LoopMoveSFX");
    }
}
