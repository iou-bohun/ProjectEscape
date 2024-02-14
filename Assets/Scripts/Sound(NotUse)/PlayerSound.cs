using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] walkMetalV1;
    public AudioClip[] runMetalV1;
    public AudioClip[] walkRock;
    public AudioClip[] runRock;


    public AudioClip[] jumpStartMetalV1;
    public AudioClip[] jumpLandMetalV1;
    public AudioClip[] jumpStartRock;
    public AudioClip[] jumpLandRock;

    public bool isRun = false; // �÷��̾ �ٰ� �ִ°�?
    public bool isGrounded = false; // �÷��̾ �ٴڿ� �پ� �ִ°�?
    private bool isGroundedOnce = false;

    private void Update()
    {
        CheckGroundedOnce();
    }

    IEnumerator LoopMoveSFX() // �÷��̾� ������ ���� �ڷ�ƾ
    {
        while (true)
        {
            if (isGrounded) // �ٴڿ� �پ��ְ�
            {
                if (isRun == false) // �Ȱ� �ִٸ�
                {
                    float wait = PickRandomSFX("WalkSFX", walkRock);
                    yield return new WaitForSeconds(wait);
                }
                else // �ٰ� �ִٸ�
                {
                    float wait = PickRandomSFX("RunSFX", runRock);
                    yield return new WaitForSeconds(wait);
                }
            }
            else
            {
                yield return null; 
            }
        }
    }

    public float PickRandomSFX(string tag, AudioClip[] inputs) // AudioClip[] �߿��� �ϳ� �̰� tag�� �ٿ� SoundManager�� ����. return���� �Ҹ� ����.
    {
        int rand = Random.Range(0, inputs.Length); // �ҽ� ���� �̱�
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
        PickRandomSFX("JumpStartSFX", jumpStartRock);
    }

    public void OnLand()
    {
        PickRandomSFX("JumpLandSFX", jumpLandRock);
    }

    public void OffWalk()
    {
        StopCoroutine("LoopMoveSFX");
    }
}
