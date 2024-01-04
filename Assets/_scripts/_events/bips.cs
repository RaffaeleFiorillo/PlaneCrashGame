using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bips : MonoBehaviour
{
    [SerializeField] AudioResource oneBip;
    [SerializeField] AudioResource twobips;
    // Start is called before the first frame update

   [SerializeField] AudioSource mainSource;
    AudioSource audioSource;

    float nextBip = 1.5f;

    bool firstLoop;
    bool activated;
    bool firstPress;
    bool lastBip;
    bool spaming;
    float timeSpam;
   


    [SerializeField] float timing;

    float keyTime;
   [SerializeField] int times;

    float timer;
    bool leftB;
    bool rightB;
    bool firstPlay;
    bool stopSpaming;
    inputting input;

    private void Update()
    {
        if (!firstLoop)
        {
            input = inputting.instance;

            firstLoop = true;

            audioSource=GetComponent<AudioSource>();
        }

        if (activated)
        {if(!mainSource.isPlaying)
            {
                if (!firstPlay)
                {
                    audioSource.resource = oneBip;
                    audioSource.Play();
                    firstPlay = true;
                }

            active();
            inputReceiver();

            }
            //Debug.Log(leftB + " " + rightB);
        }
    }


    public void receiver(scriptableSound audio)
    {
        timer = audio.timing ;
        activated = true;
        firstPress = false;
        firstPlay = false;
        timeSpam = 0f;
        times = Mathf.FloorToInt(audio.times);



    }


    void inputReceiver()
    {
        leftB = input.leftButton;
        rightB = input.rightButton;
    }


    public void active()
    {




        timer -= Time.deltaTime;


     
 

        if(leftB && rightB)
        {



            if (firstPress == false)
            {

                timeSpam = 0;


            firstPress = true;
            }
timeSpam += Time.deltaTime;

         

                if (timeSpam >timing)
                {
                if (!lastBip)
                {

                    audioSource.resource = twobips;
                    audioSource.Play();
              //  Debug.Log("yes im here motherfucker");
                    lastBip = true;
                }

                }

   if (timeSpam > 6)
            {

                timer = 0;
            }

        }
        else
        {
            lastBip = false;

            if (firstPress)
            {

            if(timeSpam >= timing)
            {
               
                    
                    if (times > 0)
                    {
                    Debug.Log("in here mate");
                        nextBip -= Time.deltaTime;

                        if(nextBip <= 0)
                        { 
                            
                            times--;

                            nextBip = 1.5f;
                            if(times != 0)
                            {

                        audioSource.resource = oneBip;
                        audioSource.Play();
                            }
                        
                        
                            firstPress = false;
                        }


                      

                    }

                        

            }
            else { timer = 0;
                }
            if(nextBip<=0)
            timeSpam = 0;
            }




        }

     



        



        if (times ==0)
        {
            eventMannager.instance.receive(0);

            activated = false;
            Debug.Log("here babe");
        }

        if (timer <= 0)
        {
            eventMannager.instance.receive(1);
            activated = false;
            Debug.Log("here");
        }
    }


    public void deactivate()
    {
        activated = false;
    }




}
