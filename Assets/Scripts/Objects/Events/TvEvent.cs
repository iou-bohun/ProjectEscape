using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(StudioEventEmitter))]
public class TvEvent : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    private Renderer _renderer;
    // Audio
    private StudioEventEmitter emitter;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _videoPlayer = GetComponent<VideoPlayer>();
        EventManager.I.livingRoomEvent += PlayVideo;
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.TVStatic, this.gameObject);
    }

    private void PlayVideo()
    {
        _videoPlayer.enabled = true;
        _videoPlayer.Play();
        emitter.SetParameter("TVEnd", 0.1f);
        emitter.Play();
        _renderer.material.color = Color.white;
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
