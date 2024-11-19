using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject enemyPrefab;

    [Header("Location")]
    [SerializeField] private float spawnRangeX = 10;
    [SerializeField] private float spawnRangeZ = 7;

    [Header("Waves")]
    public int waveNumber = 1;
    public int enemyCount;

    [Header("Game Over")]
    private PlayerControl playerControlScript;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);


        //Player
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy Count
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPositions(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPositions()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
