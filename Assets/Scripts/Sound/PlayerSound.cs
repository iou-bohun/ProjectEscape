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
            Debug.Log("LoopWalkSFX ���� ���Դϴ�.");
        }
    }

    public float SFXWalk()
    {
        int rand = Random.Range(0, walkMetalV1.Length); // �ҽ� ���� �̱�
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
