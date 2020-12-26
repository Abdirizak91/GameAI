using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Wander : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;

    public float moveSpeed = 1f;

    public float rotSpeed = 60f;

    private bool isWandering = false;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    private bool isWalking = false;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (DogOptions.WatchTheDog == true || DogOptions.ControlTheDog == true)
        {
            if (isWandering == false)
            {
                StartCoroutine(Wanderer());

            }

            if (isRotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }

            if (isRotatingLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }

            if (isWalking == true)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
   

    }

    IEnumerator Wanderer()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLoR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWandering = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLoR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLoR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;


    }
}
