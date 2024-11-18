using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Rigidbody")]
    [SerializeField] private Rigidbody enemyRb;
    private GameObject player;

    [Header("Death")]
    public bool hasBeenHit = false;
    public float deathDelay;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody
        enemyRb = GetComponent<Rigidbody>();

        //Find Player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Follow Player
        Vector3 lookDirection = (player.transform.position - transform.position * speed).normalized;

        enemyRb.AddForce(lookDirection * speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
