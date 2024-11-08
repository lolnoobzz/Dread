using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

[System.Serializable]
public class MySubtitle
{
    public string text;
    public float startTime;
    public float endTime;
    
}

public class subtitlesss : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    public List<MySubtitle> subtitles = new List<MySubtitle>
    {
        new MySubtitle { text = "HOLY, what is happening out there?", startTime = 5f, endTime = 10f },
        new MySubtitle { text = "What in the actual f*ck, ZOMBIES????", startTime = 15f, endTime = 20f },
        new MySubtitle { text = "It seems the CORONA has evolved, what are we gonna do ???", startTime = 25f, endTime = 30f },
        new MySubtitle { text = "It seems the whole world is in a cluster f*ck now, we are all doomed.", startTime = 30f, endTime = 35f },
        new MySubtitle { text = "There isn't much time left, I got to go.", startTime = 40f, endTime = 45f }
    };

    public TextMeshProUGUI subtitleText; // Reference to TextMeshPro component

    void Update()
    {
        float currentTime = (float)videoPlayer.time;

        if (videoPlayer.isPlaying)
        foreach (MySubtitle subtitle in subtitles)
        {
            if (currentTime >= subtitle.startTime && currentTime <= subtitle.endTime)
            {
                subtitleText.text = subtitle.text;
                return;
            }
        }
         subtitleText.text = "";
    }
    
 }
