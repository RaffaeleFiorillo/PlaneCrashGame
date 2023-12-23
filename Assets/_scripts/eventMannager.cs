using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using evenEnum;

public class eventMannager : MonoBehaviour
{
    bool active;
    public static eventMannager instance;
    
    timerEvent timerE;
    twoButtonEvent twoButtonEv;
    eachSideEvent eachSideEv;
    oneWayEvent oneWayEv;
    void Start()
    {
        instance = this;
        timerE = GetComponent<timerEvent>();
        twoButtonEv = GetComponent<twoButtonEvent>();
        eachSideEv = GetComponent<eachSideEvent>();
        oneWayEv = GetComponent<oneWayEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        

      




    }


    public void activation(scriptableSound theSound)
    {


        switch (theSound.nextEvent)
        {

            case theEnum.timer:

                timerE.activation(theSound);
                soundMannager.Instance.firstClose = false;

                break;


            case theEnum.twoButtonEven:
                twoButtonEv.receiver(theSound);

                break;

            case theEnum.eachSideBEvent:

                eachSideEv.receiver(theSound);

                break;

            case theEnum.oneWayBEvent:
                oneWayEv.receiver(theSound);
                break;




        }


    }

    public void deactivate(scriptableSound theSound)
    {


        switch (theSound.nextEvent)
        {

            case theEnum.timer:

                timerE.deactivate();
                

                break;
            case theEnum.twoButtonEven:

                twoButtonEv.deactivate();
                break;
            case theEnum.eachSideBEvent:
                eachSideEv.deactivate();

                break;
            case theEnum.oneWayBEvent:


                oneWayEv.deactivate();
                break;


        }

    }


    public void receive(int variant)
    {

        soundMannager.Instance.nextVariant(variant);
  


    }


}
