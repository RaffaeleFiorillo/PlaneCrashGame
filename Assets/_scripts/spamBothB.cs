using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamBothB : MonoBehaviour
{
    bool firstLoop;
    bool activated;
    [SerializeField] float timePressing;
    [SerializeField] float pressingSpeed;
    bool spaming;
    float timeSpam;

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
            active();
            inputReceiver();

            //Debug.Log(leftB + " " + rightB);
        }
    }


    public void receiver(scriptableSound audio)
    {
        timer = audio.timing;
        activated = true;
    }


    void inputReceiver()
    {
        leftB = input.leftButton;
        rightB = input.rightButton;
    }


    public void active()
    {
        if ( spaming )
        {
            timeSpam += Time.deltaTime;
        }

        if (leftB && rightB)
        { 
            spaming = true;
        }
        else
        {
            timeSpam -= Time.deltaTime;

            if (timeSpam < 0)
            {
                timeSpam = 0;
                spaming = false;
            }
        }

        if (leftB && rightB)
        {
            // Debug.Log("working");
            if (timePressing > 0)
            {
                timePressing -= pressingSpeed * Time.deltaTime;
            }
        }

        timer -= Time.deltaTime;

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
