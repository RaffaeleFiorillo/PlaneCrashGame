using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{


    [SerializeField] AudioSource main;

    bool active;




    private void Update()
    {
        if (active)
            if(!main.isPlaying)
            {

            activate();
            }

    }
    public void receiving()
    {



 active = true;



    }


    public void activate()
    {

        SceneManager.LoadScene("credits");



    }
}
