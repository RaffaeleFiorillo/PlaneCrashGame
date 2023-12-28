using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using static UnityEditor.UIElements.ToolbarMenu;


public class soundMannager : MonoBehaviour
{
    public static soundMannager Instance;
    bool firstLoop;

    [SerializeField] scriptableSound firstScriptableSound;



    scriptableSound nextSound;
    int nextAudio;
    float timer = 6;
    bool timerOn = false;

    inputting inputing;

    UnityEvent nextAudioEvent;

    scriptableSound openingEyes;
    bool inputOpening;

    bool areOpened;
    public bool firstClose;
    AudioSource soundSource;


    private void Start()
    {
        Instance = this;

        soundSource = GetComponent<AudioSource>();
        nextSound = firstScriptableSound;

        soundSource.resource = nextSound.audio;
        soundSource.Play();
    }


    private void Update()
    {
        if (!firstLoop)
        {
            firstLoop = true;
            inputing = inputting.instance;
        }

        timer -= timerOn ? Time.deltaTime : 0;

        if (firstClose)
        {
            if (inputing.closeOpenEye) inputOpening = !inputOpening;

            if (inputOpening)
            {
                eyesOpen();
            }
            else
            {
                eyesShut();
                passToNext();
            }
        }
        else
        {
            passToNext();
        }
    }


    public void playSound()
    {
        soundSource.Play();
    }


    public void endSound()
    {
        soundSource.Stop();
    }


    public void passToNext()
    {
        if (!soundSource.isPlaying && nextSound.noEvent)
        {
            nextSound = nextSound.variants[0];
            soundSource.resource = nextSound.audio;

           // Debug.Log("calling");
            playSound();
            if (!nextSound.noEvent)
                eventMannager.instance.activation(nextSound);
        }
    }


    public void nextVariant(int variant)
    {
        if(soundSource.isPlaying)
        {
            endSound();
        }


        if (!soundSource.isPlaying) 
        {
            Debug.Log("im alive");
            
                nextSound = nextSound.variants[variant]; 
            
            
            soundSource.resource = nextSound.audio;

            timer = soundSource.time;
          //  Debug.Log("received");

            playSound();

            if (!nextSound.noEvent)
            {
                eventMannager.instance.activation(nextSound);
              //  Debug.Log("variating");
            }
        }
    }


    public void eyesOpen()
    {
        if (!areOpened)
        {
            areOpened = true;
            soundSource.Stop();

            soundSource.resource = nextSound.notFollowAudio;

            soundSource.Play();

            eventMannager.instance.deactivate(nextSound);
        }
    }


    public void eyesShut()
    {
        if (areOpened)
        {
            areOpened = false;
            soundSource.Stop();

            //nextSound = nextSound.variants[0];

            soundSource.resource = nextSound.audio;

            if (!nextSound.noEvent)
            {
                eventMannager.instance.activation(nextSound);
                Debug.Log("variating");
            }

            soundSource.Play();
        }
    }


    public void firstCloser()
    {
    }
}
