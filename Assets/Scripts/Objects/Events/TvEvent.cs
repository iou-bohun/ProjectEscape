using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(StudioEventEmitter))]
public class TvEvent : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private Renderer _renderer;

    // Audio
    private StudioEventEmitter emitter;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _renderer = GetComponent<Renderer>();
        EventManager.I.livingRoomEvent += PlayVideo;
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.TVStatic, this.gameObject);
    }

    private void PlayVideo()
    {
        _videoPlayer.enabled = true;
        _renderer.material.color = Color.white;
        _videoPlayer.Play();
        emitter.SetParameter("TVEnd", 0.1f);
        emitter.Play();
        StartCoroutine(OffVideo()); 
    }

    IEnumerator OffVideo()
    {
        yield return new WaitForSeconds(10f);
        _videoPlayer.enabled = false;
        _renderer.material.color = Color.black;
        emitter.SetParameter("TVEnd", 1.0f);
        yield return new WaitForSeconds(3f);
        emitter.Stop();
    }
}
