using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenerCloser : MonoBehaviour
{
    
    public Animator anim;
    
    void Start()
    {
        
            anim = GetComponent<Animator>();
          

    }


    void Update()
    {
        //make the goal invisible
        //GameObject.Find("Goal").GetComponent<MeshRenderer>().enabled = false;

        //make the gateline invisible 
        //GameObject.Find("GateLine").GetComponent<MeshRenderer>().enabled = false;

        // if E is pressed the door opens 
        if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("CloseOpen");
            }


        //if R is pressed the scene restarts
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }


}
