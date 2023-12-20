using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class soundMannager : MonoBehaviour
{


    [SerializeField] scriptableSound firstScriptableSound;
    scriptableSound nextSound;
    int nextAudio;


    UnityEvent nextAudioEvent;

    AudioSource soundSource;


    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
        nextSound = firstScriptableSound;

        soundSource.resource = nextSound.audio;
        soundSource.Play();


    }


    public void playSound()
    {

        soundSource.Play();

       


    }
    public void endSound()
    {


        soundSource.Stop();
    }


    public void nextVariant(int variant)
    {



        if (!soundSource.isPlaying)
        {
            nextSound = nextSound.variants[variant];

            soundSource.resource = nextSound.audio;



        }
    }
    


}
