using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timerEvent : MonoBehaviour
{
    ScriptableObject theSound;
    bool activeBool;
    float timer;

    bool eyeOpen;
    bool eyesClosed;


    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!activeBool)
        {
            active();
            // Debug.Log(timer);
            receiveInput();
        }
    }


    void receiveInput()
    {
        eyeOpen = inputting.instance.closeOpenEye;
        if (eyeOpen) eyesClosed = !eyesClosed;
    }


    public void activation(scriptableSound sounding)
    {
        theSound = sounding;
        timer = sounding.timing;

        activeBool = true;
    }


   public void active()
    {
        if (eyesClosed)
        {
            eventMannager.instance.receive(0);
            activeBool = false;
            soundMannager.Instance.firstClose = true;
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            activeBool = false;
            eventMannager.instance.receive(1);
        }
    }


    public void deactivate()
    {
        activeBool = false;
    }
}
