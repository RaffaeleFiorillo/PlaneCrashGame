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
    spamBothB spamBothBEv;
    bips bipsEvent;
    nextScene theEnd;

    void Start()
    {
        instance = this;
        timerE = GetComponent<timerEvent>();
        twoButtonEv = GetComponent<twoButtonEvent>();
        eachSideEv = GetComponent<eachSideEvent>();
        oneWayEv = GetComponent<oneWayEvent>();
        spamBothBEv = GetComponent<spamBothB>();
        bipsEvent = GetComponent<bips>();
        theEnd = GetComponent<nextScene>();
    }


    // Update is called once per frame
    void Update()
    {
    }


    public void activation(scriptableSound theSound)
    {
        soundMannager.Instance.eventBool = true;
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

            case theEnum.spamBothBEvent:
               spamBothBEv.receiver(theSound);
                break;
            case theEnum.bipsEvent:
                bipsEvent.receiver(theSound); 
                
                break;
            case theEnum.End:
                theEnd.receiving();


                break;
        }
    }


    public void deactivate(scriptableSound theSound)
    {
        soundMannager.Instance.eventBool = false;
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
            case theEnum.spamBothBEvent:
                spamBothBEv.deactivate();
                break;
                case theEnum .bipsEvent:
                bipsEvent.deactivate();
                break;
           





        }
    }


    public void receive(int variant)
    {
        soundMannager.Instance.nextVariant(variant);

    }
}
