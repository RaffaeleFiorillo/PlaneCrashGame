using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamBothB : MonoBehaviour
{
    bool firstLoop;
    bool activated;
 
    bool spaming;
    bool spam;
    float timeSpam;
    [SerializeField] float timeToSpam;

    [SerializeField] AudioSource mainSource;
    [SerializeField] float timeSpaming;

    float keyTime;

    float timer;
    bool leftB;
    bool rightB;

    bool stopSpaming;
    inputting input;

    private void Update()
    {
        if (!firstLoop)
        {
            input = inputting.instance;

            firstLoop = true;
        }

        if (activated)
        {
            if (!mainSource.isPlaying)
            {

            active();
            inputReceiver();

            }

            //Debug.Log(leftB + " " + rightB);
        }
    }


    public void receiver(scriptableSound audio)
    {
        activating();
        timer = audio.timing;
        timeToSpam = audio.times;
       
    }


    void inputReceiver()
    {
        leftB = input.leftButton;
        rightB = input.rightButton;
    }

    void activating()
    {
        activated = true;
    }
    public void active()
    {


        

        timer -= Time.deltaTime;


        


        if ( spaming )
        {
            timeSpam += 2*Time.deltaTime;
           


        }

        if (leftB && rightB)
        {
            if (!spam)
            {
                spam = true;

            spaming = true;
            timeSpaming = 0;
            }
        }
        else
        {
            spam = false;
          
            timeSpam -= Time.deltaTime;
            timeSpaming += Time.deltaTime;
            if (timeSpaming >= 1f)
            {


            timeSpam = 0;
                spaming = false;

            }


            

            
        }



        if (timeSpam >=timeToSpam)
        {
            eventMannager.instance.receive(0);

            activated = false;
            timeSpaming = 0;
            timeSpam = 0;
            
        }

        if (timer <= 0)
        {
            eventMannager.instance.receive(1);
            activated = false;
            timeSpaming = 0;
            timeSpam = 0;
              Debug.Log("é do timer");
        }
    }


    public void deactivate()
    {
        Debug.Log(activated);
        activated = false;
    }
}
