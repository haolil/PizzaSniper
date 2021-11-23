using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeLock : MonoBehaviour
{
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(audio.volume >= 0.3f)
        {
            audio.volume = 0.3f;
        }
    }
}
