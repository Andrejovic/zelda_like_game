using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_play : MonoBehaviour
{   
    AudioSource my_audio;
    // Start is called before the first frame update
    void Start()
    {
        my_audio = GetComponent<AudioSource>();
    }
    
    public void play_sound()
    {
        my_audio.Play();
    }
}
