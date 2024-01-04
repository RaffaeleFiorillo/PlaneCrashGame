using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class twoButtonEvent : MonoBehaviour
{
    bool firstLoop;
    bool activated;
    [SerializeField] float timePressing;
    [SerializeField] float pressingSpeed;

[SerializeField]    AudioSource mainaudio;

    float timer;
    bool leftB;
    bool rightB;

    inputting input;


    private void Update()
    {
        if (!firstLoop)
        {
            input = inputting.instance;
            firstLoop = true;
          
        }

        if (activated)
        {if(!mainaudio.isPlaying)
            {

            active();
            inputReceiver();

            }

            //Debug.Log(leftB + " " + rightB);
        }
    }


    public void receiver(scriptableSound audio)
    {
        timer = audio.timing;
        timePressing = audio.times;
        activated = true;
    }


    void inputReceiver()
    {
        leftB = input.leftButton;
        rightB= input.rightButton;
    }


    public void active()
    {
        if ( leftB && rightB && timePressing > 0)
        {
             timePressing -= pressingSpeed * Time.deltaTime;
        }

        timer -=Time.deltaTime;

        if (timePressing <= 0)
        {
            eventMannager.instance.receive(0);
            activated = false;
        }

        if (timer <= 0)
        {
            eventMannager.instance.receive(1);
            activated = false;
        }
    }


    public void deactivate()
    {
        activated = false;
    }
}
