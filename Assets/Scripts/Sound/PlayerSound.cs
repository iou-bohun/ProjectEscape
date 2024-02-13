using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] walkMetalV1;
    public AudioClip[] runMetalV1;

    public bool isRun = false; // �÷��̾ �ٴ°�?


    IEnumerator LoopMoveSFX()
    {
        while (true)
        {
            if (isRun == false)
            {
                float wait = SFXWalk("WalkSFX", walkMetalV1);
                yield return new WaitForSeconds(wait);
                Debug.Log("�ȴ� �Ҹ� �ݺ� ��� ���Դϴ�.");
            }
            else
            {
                float wait = SFXWalk("RunSFX", runMetalV1);
                yield return new WaitForSeconds(wait);
                Debug.Log("�ٴ� �Ҹ� �ݺ� ��� ���Դϴ�.");
            }
        }
    }

    public float SFXWalk(string tag, AudioClip[] inputs)
    {
        int rand = Random.Range(0, inputs.Length); // �ҽ� ���� �̱�
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
