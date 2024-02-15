using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEvent : MonoBehaviour
{
    [SerializeField] private GameObject _originMirror;
    [SerializeField] private GameObject _brokenMirror;

    private void Start()
    {
        EventManager.I.bathRoomEvent += BreakMirror;
    }

    private void BreakMirror()
    {
        StartCoroutine(StartBreak());
    }

    IEnumerator StartBreak()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.glassBreaking , this.transform.position);
        _originMirror.gameObject.SetActive(false);
        _brokenMirror.gameObject.SetActive(true);
    }
}
