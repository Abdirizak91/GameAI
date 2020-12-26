using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOptions : MonoBehaviour
{

    public static bool ControlTheDog = false;
    public static bool WatchTheDog = false;

    // event handler method for watch dog button 
    public void WatchDog()
    {
        //get game component 
        GameObject.Find("Dog").GetComponentsInChildren<DogAI>();
        // set the dog watch bool to true
        WatchTheDog = true;
        // make the watch dog button disappear
        GameObject.Find("WatchDogButton").SetActive(false);
        // make the control dog button disappear
        GameObject.Find("ControlDogButton").SetActive(false);
        // make the control watch text disappear
        GameObject.Find("ControlWatchText").SetActive(false);
    }


    public void ControlDog()
    {
        // set control the dog to true
        ControlTheDog = true;                                                 // the booleans are used to control other scripts with if statements, to play certain scripts based on these booleans for watch or control
        // make the watch dog button invisible 
        GameObject.Find("WatchDogButton").SetActive(false);
        // make the control dog button invisible 
        GameObject.Find("ControlDogButton").SetActive(false);
        // control watch text set it to invisible
        GameObject.Find("ControlWatchText").SetActive(false);
        // make the gate key text to visible 
        GameObject.Find("GateKeyText").SetActive(true);

    }
}
