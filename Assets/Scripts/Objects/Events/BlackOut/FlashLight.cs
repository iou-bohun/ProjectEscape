using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light spotLight;
    public Light pointLight;
    private bool isBlackOutStart;
    WaitForSeconds waitTime;

    void Start()
    {
        waitTime = new WaitForSeconds(1);
        StartCoroutine(FlashBettery());
    }


    IEnumerator FlashBettery()
    {
        while (!LightManager.instance.isPlayerDie)
        {
            isBlackOutStart = LightManager.instance.isBlackOutEvent;
            if (isBlackOutStart)
            {
                if(spotLight.intensity > 0&&pointLight.intensity>0) 
                {
                    spotLight.intensity -= 0.1f;
                    pointLight.intensity -= 0.05f;
                    yield return waitTime;
                }
                else
                {
                    Debug.Log("베터리끝");
                    PlayerDie();
                    yield return null;
                }
            }
            else
            {
            yield return waitTime;
            }

        }

    }
    private void PlayerDie()
    {
        LightManager.instance.isPlayerDie = true;
        StopCoroutine(FlashBettery());
    }
}
