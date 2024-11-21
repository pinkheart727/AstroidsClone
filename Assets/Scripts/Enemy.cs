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

    [Header("Game Over")]
    private PlayerControl playercontrolScript;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody
        enemyRb = GetComponent<Rigidbody>();

        //Find Player
        player = GameObject.Find("Player");
        playercontrolScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        //Follow Player if Game continues
        if (playercontrolScript.gameOver == false)
        {
            Vector3 lookDirection = (player.transform.position - transform.position * speed).normalized;

            transform.Translate(lookDirection * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
