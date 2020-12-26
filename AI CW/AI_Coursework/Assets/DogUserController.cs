using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogUserController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody rb;
    private Vector3 inputVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the control the dog button is clicked the user is able to control the dog 
        if (DogOptions.ControlTheDog == true)
        {
            inputVector = new Vector3(Input.GetAxis("Horizontal") * 6f, rb.velocity.y, Input.GetAxis("Vertical") * 6f);
            transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
            rb.velocity = inputVector;
        }
        
    }
}
