using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OpenCutscene : MonoBehaviour
{
    public VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.
    }

    public void SkipButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
