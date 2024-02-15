using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvEvent : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        EventManager.I.livingRoomEvent += PlayVideo;
    }

    //On TV
    private void PlayVideo()
    {
        _videoPlayer.enabled = true;
        _videoPlayer.Play();
        StartCoroutine(OffVideo()); 
    }

    //OffTV
    IEnumerator OffVideo()
    {
        yield return new WaitForSeconds(10f);
        _videoPlayer.enabled = false;
    }
}
