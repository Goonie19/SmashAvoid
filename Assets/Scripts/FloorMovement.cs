using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{

    [SerializeField] private static float speed;

    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * -1 * speed);

        if (transform.position.z < 0)
            Deactivate();
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void addSpeed(float i)
    {
        speed += i;
    }

    public float getSpeed()
    {
       return speed;
    }
}
