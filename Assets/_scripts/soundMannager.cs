using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class soundMannager : MonoBehaviour
{


    [SerializeField] List<scriptableSound> sounds = new List<scriptableSound>();
    int nextAudio;


    UnityEvent nextAudioEvent;

    AudioSource soundSource;


    private void Start()
    {
        soundSource = GetComponent<AudioSource>();



    }

    
    


}
