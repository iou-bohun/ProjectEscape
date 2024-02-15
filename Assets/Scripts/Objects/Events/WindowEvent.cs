using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


[RequireComponent(typeof(StudioEventEmitter))]
public class WindowEvent : MonoBehaviour
{
    private Animator animator;

    // Audio
    private StudioEventEmitter emitter;
    private bool isRattle;
    private bool isRattleOnce;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.bedRoomEvent += ShakeWindow;
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.windowRattle, this.gameObject);
        isRattle = false;
        isRattleOnce = false;
    }

    private void Update()
    {
        UpdateSound();
    }

    public void ShakeWindow()
    {
        isRattle = true;
    }

    private void UpdateSound()
    {
        if (isRattle && !isRattleOnce)
        {
            animator.SetBool("Shake", true);
            emitter.SetParameter("WindowRattleEnd", 0.1f);
            emitter.Play();
            StartCoroutine(StartTimer());
            isRattleOnce = true;
        }
        else if (!isRattle && isRattleOnce)
        {
            StartCoroutine(StopShakingEvent());
            isRattleOnce = false;
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(5f);
        isRattle = false;
    }

    IEnumerator StopShakingEvent()
    {
        emitter.SetParameter("WindowRattleEnd", 1.0f);
        yield return new WaitForSeconds(4f);
        animator.SetBool("Shake", false);
        emitter.Stop();
    }

    
}
