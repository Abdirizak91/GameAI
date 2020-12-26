using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public static Vector3 furthestSheep;
    static float distance;
    public static GameObject FurthestObject = null;
    static float FurthestDistance = 0;
    public GameObject WayPoint;
    public GameObject Sheep;
    public static int ParameterSize = 5;
    static int SheepNum = 10;

    public static GameObject[] AllSheeps = new GameObject[SheepNum];

    public static Vector3 goalPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SheepNum; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-22, -12),
                                      Random.Range(-ParameterSize, ParameterSize),
                                      Random.Range(-30, -20));

            AllSheeps[i] = (GameObject) Instantiate(Sheep, pos, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
            if (Random.Range(0, 10000) < 50)
            {
                goalPos = new Vector3(Random.Range(-ParameterSize, ParameterSize),
                    Random.Range(-ParameterSize, ParameterSize),
                    Random.Range(-ParameterSize, ParameterSize));
            }
        
      
    }




}
