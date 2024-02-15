using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class WindowEvent : MonoBehaviour
{
    private Animator animator;

    // Audio
    private EventInstance windowRattle;
    private bool isRattle;
    private bool isRattleOnce;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.bedRoomEvent += ShakeWindow;
        windowRattle = AudioManager.instance.CreateInstace(FMODEvents.instance.windowRattle);
        isRattle = false;
        isRattleOnce = false;
    }

    private void Update()
    {
        UpdateSound();
    }

    public void ShakeWindow()
    {
        animator.SetBool("Shake", true);
        isRattle = true;
        StartCoroutine(EndEvent());
    }

    private void UpdateSound()
    {
        if (isRattle && !isRattleOnce)
        {
            windowRattle.setParameterByName("WindowRattleEnd", 0f);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.windowRattle, this.transform.position);
            isRattleOnce = true;
        }
        else if (!isRattle && isRattleOnce)
        {
            windowRattle.setParameterByName("WindowRattleEnd", 1.0f);
        }
    }

    //End Shaking
    IEnumerator EndEvent()
    {
        yield return new WaitForSeconds(10f);
        animator.SetBool("Shake", false);
    }

}
