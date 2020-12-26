using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = System.Numerics.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class flee : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject Player;
    public float EnemyDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    
    // Update is called once per frame
    void Update()
    {



        if (DogOptions.ControlTheDog == true || DogOptions.WatchTheDog)
        {
            _agent.baseOffset = 0;
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < EnemyDistanceRun)
            {

                Vector3 dirToDog = transform.position - Player.transform.position;
                Vector3 newPos = transform.position + dirToDog;

                _agent.SetDestination(newPos);
            }

        }

        

     

    }


}
