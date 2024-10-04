using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoScript : MonoBehaviour
{
    
    [SerializeField] string videoName;

    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }
    public void PlayVideo()
    {
    VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null) {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
