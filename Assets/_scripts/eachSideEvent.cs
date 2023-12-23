using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eachSideEvent : MonoBehaviour
{

   // [SerializeField] float passingOb;
    bool actived;

    float timer;

    [SerializeField] float eixo;
    [SerializeField] float eixoLength;
    [SerializeField] float speed;

    bool firstLoop;

    bool leftInp;
    bool rightInp;

    inputting input;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!firstLoop)
        {
            firstLoop = true;

            input = inputting.instance;

        }


        if (actived)
        {

        inputReceiver();
            activation();


        }


    }

    public void inputReceiver()
    {

        leftInp = input.leftButton;
        rightInp = input.rightButton;





    }

    public void receiver(scriptableSound som)
    {

       actived =true;
        timer = som.timing;

        eixo = 0;


    }
    
    public void activation()
    {
            timer -=Time.deltaTime;

        if(timer > 0)
        {

            if (leftInp)
            {
                eixo -= speed * Time.deltaTime;



            }
            if(rightInp)
            {
                eixo += speed * Time.deltaTime;

            }




        }


        if(timer <=0)
        {
            eventMannager.instance.receive(1);


            actived = false;


        }



        if(eixo >= eixoLength|| eixo <= -eixoLength)
        {

            eventMannager.instance.receive(0);


            actived = false;


        }



    }
    public void deactivate()
    {


        actived = false;

    }

}
