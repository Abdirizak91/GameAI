
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    { 
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothposition;

        transform.LookAt(target);
    }
}
