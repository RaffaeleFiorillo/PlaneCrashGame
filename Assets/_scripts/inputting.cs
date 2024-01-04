using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputting : MonoBehaviour
{
    public static inputting instance;



    public bool closeOpenEye;

    public bool leftButton;
    public bool rightButton;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        inputing();
    }





    public void inputing()
    {



       // closeOpenEye = Input.GetKeyDown(KeyCode.P);
       // closeOpenEye = Input.GetKeyUp(KeyCode.P);

        closeOpenEye = (Input.GetKeyDown(KeyCode.P)) ? true : false;

        leftButton = Input.GetKey(KeyCode.LeftControl);
       // leftButton = Input.GetKeyUp(KeyCode.A);

        rightButton = Input.GetKey(KeyCode.RightControl);
       // rightButton =Input.GetKeyUp(KeyCode.L);


      
  


    }




}
