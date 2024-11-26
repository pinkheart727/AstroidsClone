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

    [Header("Death")]
    private GameManager gm;

    [Header("Audio")]
    public AudioClip shootingSound;
    public AudioClip isHitSound;
    private AudioSource playerAudio;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {
        //Game Manager
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Audio
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if (gm.isGameActive == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        }


       
        //Shooting
        if(Input.GetKeyDown(KeyCode.Space) && gm.isGameActive == true)
        {
            Instantiate(projecitlePrefab, transform.position, transform.rotation);
            playerAudio.PlayOneShot(shootingSound, 0.1f);
        }
    }

    private void FixedUpdate()
    {
        //Movement
        if (gm.isGameActive == true)
        {
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime * verticalInput);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gm.isGameActive == true)
        {
            playerAudio.PlayOneShot(isHitSound, 1.0f);
            gm.LoseLife();
        }
        if (gm.lives <= 0 && gm.isGameActive == true)
        {
            playerAudio.PlayOneShot(death, 1.0f);
            gm.GameOver();
        }
    }
}
