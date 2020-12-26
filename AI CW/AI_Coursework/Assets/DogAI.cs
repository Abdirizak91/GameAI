using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DogAI : MonoBehaviour
{
    
    public GameObject Dog;
    public GameObject Goal;
    public GameObject TheFurthestSheep; //Furthest Sheep to the Goal (dog Target)
    public GameObject ClosestSheep; // Closest Sheep to the Goal
    private float FurthestSheep = 0;
    private float closestSheep = Mathf.Infinity;
    public float speed;
    private Vector3 dogChaseSheep;
    public Animator anim;
    private float GateDistanceToGoal;
    private float ForGatesheepdistance;
    private int k;

    // Start is called before the first frame update

    // Update is called once per frame


    void start()
    {
        anim = GetComponent<Animator>();
        foreach (GameObject sheep in Flock.AllSheeps)
        {
            // distance between sheeps and goal
            float sheepdistance = Vector3.Distance(Goal.transform.position, sheep.transform.position);

            //if sheeps are more than FurthestSheep get the furthestsheep
            if (sheepdistance > FurthestSheep)
            {
                TheFurthestSheep = sheep;
                FurthestSheep = sheepdistance;

            }

        }
    }


    void Update()
    {

        if (DogOptions.WatchTheDog == true)
        { 

            //loop through all sheeps 
            foreach (GameObject sheep in Flock.AllSheeps)
        {
            // distance between sheeps and goal
            float sheepdistance = Vector3.Distance(Goal.transform.position, sheep.transform.position);
            
            //if sheeps are more than FurthestSheep get the furthestsheep
            if (sheepdistance > FurthestSheep)
            {
                TheFurthestSheep = sheep;
                FurthestSheep = sheepdistance;

            }

            //calculate the distance between the gate and the goal so when the sheep past that distance to close the gate
           GateDistanceToGoal =
                Vector3.Distance(GameObject.Find("GateLine").transform.position, Goal.transform.position);
            Debug.Log("GATE : " + GateDistanceToGoal);

            // the distance between the sheep and the gate, this is is for code at line 140 to close the gate when sheep goes past gate
            ForGatesheepdistance = Vector3.Distance(sheep.transform.position, Goal.transform.position);

            // get distance of all sheeps from the goal getting the closest sheep 
            float sheepdistance2 = Vector3.Distance(Goal.transform.position, sheep.transform.position);

            //if the distance is less than the closestSheep
            if (sheepdistance2 < closestSheep)
            {
                // The closest Sheep is this object
                ClosestSheep = sheep;
                closestSheep = sheepdistance2;
            }
            
            Debug.DrawLine(Goal.transform.position, ClosestSheep.transform.position);
            // finding the mid point between the goal and the closest sheep 
            Vector3 midpoint = (Goal.transform.position + Dog.transform.position) / 2;

            // draw a line to see the furthest sheep
            Debug.DrawLine(Goal.transform.position, TheFurthestSheep.transform.position);
            
            //The Dog Looks at the nearest Sheep
            Dog.transform.LookAt(TheFurthestSheep.transform.position);
            
            // calculate direction between the furthest sheep and goal
            Vector3 direction = TheFurthestSheep.transform.position - Goal.transform.position;

            // calculate the angle using the inverse tangent method returning the radian
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log("Angle: " + angle);
           
            // converting the angle to Vector 3
            var vForce = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

                // The Dog will attack the sheep from the opposite angle of the gate (target is -vForce) so it herds it to the gate
                speed = 6f;
                dogChaseSheep = Vector3.MoveTowards(Dog.transform.position, -vForce, Time.deltaTime * speed);

            // if the dog is within a certain distance to the nearest sheep all the sheeps move to a certain distance away from the dog
            if (dogChaseSheep == Vector3.MoveTowards(Dog.transform.position, -vForce, Time.deltaTime * speed))
            {

                sheep.transform.position = Vector3.MoveTowards(sheep.transform.position, ClosestSheep.transform.position, Time.deltaTime * 6f);
                TheFurthestSheep.transform.LookAt(vForce);
                sheep.transform.LookAt(vForce);
               
            }

            
            
            // define the rotation along a specific axis using the angle
            Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.left);

            // slerp from our current rotation to the new specific roatation
            Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * 20);

        }
            // dog chases furthest sheep
            speed = 6f;
            dogChaseSheep = Vector3.MoveTowards(Dog.transform.position, TheFurthestSheep.transform.position, Time.deltaTime * speed);
        Dog.transform.position = dogChaseSheep;

        // if the sheep goes past the gate 
        if (GateDistanceToGoal > ForGatesheepdistance && k == 0)
        {
            //trigger close gate anim
            anim.SetTrigger("CloseOpen");
            // increment k,  this allows the anim trigger to be played only once in the update() method 
            k++;
        }

        }
    }
}



