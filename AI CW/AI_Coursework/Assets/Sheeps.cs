using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Sheeps : MonoBehaviour
{
    public float speed = 0.05f;
    private float rotationSpeed = 1.0f;
    private Vector3 averageHeading;
    private Vector3 averagePosition;
    private float neighbourDistance = 3.0f;

    bool turning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DogOptions.WatchTheDog == true || DogOptions.ControlTheDog == true)
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
  
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = Flock.AllSheeps;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = Flock.goalPos;

        float dist;

        int GroupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    GroupSize++;

                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                   
                }
            }
        }

        if (GroupSize > 0)
        {
            vcentre = vcentre / GroupSize + (goalPos - this.transform.position);

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(direction),
                    rotationSpeed * Time.deltaTime);
        }
    }
}
