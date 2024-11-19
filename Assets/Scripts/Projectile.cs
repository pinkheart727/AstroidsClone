using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 40.0f;

    [Header("Game Over")]
    private PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        //Player
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControlScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
