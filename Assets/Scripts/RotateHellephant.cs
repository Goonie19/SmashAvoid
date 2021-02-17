using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHellephant : MonoBehaviour
{

    public float rotationSpeed;

    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(rotationSpeed < maxSpeed)
            rotationSpeed++;

        this.transform.Rotate(transform.up, Mathf.Sqrt(rotationSpeed));
    }
}
