using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject _door;

    [Header ("SFX")]
    [SerializeField] AudioClip doorOpen;
    [SerializeField] AudioClip doorClose;


    public bool isOpen;
    private bool isOnce;
    private AudioSource _source;

    private void Start()
    {
        isOpen = false;
        isOnce = false;
        _source = _door.AddComponent<AudioSource>();
    }

    private void Update()
    {
        CheckDoorOpen();
    }

    private void CheckDoorOpen()
    {
        if (isOpen && !isOnce)
        {
            OpenDoorSFX();
            isOnce = true;
        }
        else if (!isOnce)
        {
            CloseDoorSFX();
            isOnce = true;
        }
    }

    private void OpenDoorSFX()
    {
        _source.clip = doorOpen;
        _source.Play();
    }

    private void CloseDoorSFX()
    {
        _source.clip = doorClose;
        _source.Play();
    }
}
