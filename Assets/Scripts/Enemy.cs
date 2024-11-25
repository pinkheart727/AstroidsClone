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
    private GameManager gm;
    public int pointValue;

    [Header("Game Over")]
    private PlayerControl playercontrolScript;

    [Header("Prefabs")]
    public GameObject enemyPrefab;

    [Header("Scaling")]
    private float scale = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody
        enemyRb = GetComponent<Rigidbody>();

        //Find Player
        player = GameObject.Find("Player");
        playercontrolScript = GameObject.Find("Player").GetComponent<PlayerControl>();

        //Find Game Manager
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        //Follow Player if Game continues
        if (gm.isGameActive == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            transform.Translate(lookDirection * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            hasBeenHit = true;
            gm.AddScore(pointValue);
            scale = scale / 2;
            transform.localScale = new Vector3(scale, scale, scale);

            if (scale < 0.15)
            {
                Destroy(gameObject);
            }

            //Destroy(gameObject);
            
        }
    }
}
