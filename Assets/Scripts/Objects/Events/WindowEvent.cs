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

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager.I.bedRoomEvent += ShakeWindow;
        EventManager.I.livingRoomEvent += CloseWindow;
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.windowRattle, this.gameObject);
    }

    public void ShakeWindow()
    {
        if (!emitter.IsActive)
        {
            animator.SetBool("Shake", true);
            emitter.SetParameter("WindowRattleEnd", 0.1f);
            emitter.Play();
        }
    }

    public void CloseWindow()
    {
        if(emitter.IsActive)
        {
            StartCoroutine(CloseSequence());
        }
    }

    IEnumerator CloseSequence()
    {
        emitter.SetParameter("WindowRattleEnd", 1.0f);
        yield return new WaitForSeconds(3f);
        animator.SetBool("Shake", false);
        emitter.Stop();
    }
}
