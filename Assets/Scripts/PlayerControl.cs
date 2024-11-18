using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    private float horizontalInput;
    [SerializeField] private float turnSpeed;
    private float verticalInput;
    [SerializeField] private float forwardSpeed;


    [Header("Shooting")]
    public GameObject projecitlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projecitlePrefab, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        //Movement
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime * verticalInput);
    }
}
