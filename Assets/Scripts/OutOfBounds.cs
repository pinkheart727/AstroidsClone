using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [Header("Limits")]
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xMax)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < xMin)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > zMax)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < zMin)
        {
            Destroy(gameObject);
        }
    }
}
