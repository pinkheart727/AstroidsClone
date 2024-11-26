using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    //public float speed;
    public float forceRange;
    public float torqueRange;

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

    [Header("Audio")]
    public AudioClip isHitSound;
    private AudioSource enemyAudio;

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

        if (gm.isGameActive == true)
        {
            AddRandomForce();
            AddRandomTorque();
        }


        //Audio
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        //Follow Player if Game continues
        //if (gm.isGameActive == true)
        {
            //Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            //transform.Translate(lookDirection * Time.deltaTime * speed);
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
            enemyAudio.PlayOneShot(isHitSound, 0.5f);

            if (scale < 0.15)
            {
                enemyAudio.PlayOneShot(isHitSound, 0.25f);

                Destroy(gameObject);
            }

            //Destroy(gameObject);
            
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            AddRandomForce();
            AddRandomTorque();
        }
    }

    public void AddRandomForce()
    {
        float randomForceZ = Random.Range(-forceRange, forceRange);
        float randomForceX = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, 0, randomForceZ);

        enemyRb.AddForce(randomForce, ForceMode.Impulse);
    }

    public void AddRandomTorque()
    {
        float randomTorque = Random.Range(-torqueRange, torqueRange);
        enemyRb.AddTorque(Vector3.back * randomTorque, ForceMode.Impulse);
    }
}
