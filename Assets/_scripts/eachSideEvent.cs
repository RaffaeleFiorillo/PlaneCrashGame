using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eachSideEvent : MonoBehaviour
{
    float Timer;
    bool Actived;
    bool FirstLoop;

    // [SerializeField] float passingOb;
    [SerializeField] float eixo;
    [SerializeField] float eixoLength;
    [SerializeField] float speed;

    bool LeftInp;
    bool RightInp;

    inputting input;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (!FirstLoop)
        {
            FirstLoop = true;
            input = inputting.instance;
        }

        if (Actived)
        {
            inputReceiver();
            activation();
        }
    }


    public void inputReceiver()
    {
        LeftInp = input.leftButton;
        RightInp = input.rightButton;
    }


    public void receiver(scriptableSound som)
    {
        Actived = true;
        Timer = som.timing;
        eixo = 0;
    }
    

    public void activation()
    {
        Timer -= Time.deltaTime;

        if( Timer > 0 )
        {
            if (LeftInp)
            {
                eixo -= speed * Time.deltaTime;
            }

            if(RightInp)
            {
                eixo += speed * Time.deltaTime;
            }
        }
        else if( Timer <= 0 )
        {
            eventMannager.instance.receive(1);
            Actived = false;
        }

        if(eixo >= eixoLength || eixo <= -eixoLength)
        {
            eventMannager.instance.receive(0);
            Actived = false;
        }
    }


    public void deactivate()
    {
        Actived = false;
    }

}
