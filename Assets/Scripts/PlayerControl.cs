using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float horizontalInput;
    public float forwardInput;
    public float moveSpeed;
    public float turnSpeed;


    //[Header("Shooting")]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
