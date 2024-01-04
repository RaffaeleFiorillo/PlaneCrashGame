using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiMannager : MonoBehaviour
{
 soundMannager mannager;
    [SerializeField] TextMeshProUGUI missionT;
    [SerializeField] TextMeshProUGUI timeT;


    bool firstLoop;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstLoop)
        {
            mannager = soundMannager.Instance;

            firstLoop = true;
        }
        else
        {

            missionT.text ="Mission :" +mannager.nextSound.name;

            timeT.text ="Time : " + mannager.nextSound.timing;




        }
        

    }
}
