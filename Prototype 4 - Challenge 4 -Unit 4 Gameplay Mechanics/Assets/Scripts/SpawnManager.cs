using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount = 5;
    public int waveNumber = 1;
    public float respawnDelay = 2f; // Delay before spawning a new wave
    private int currentEnemyCount; // Current number of enemies in the scene


    // Start is called before the first frame update
    void Start()
    {
        // float spawnPosX = Random.Range(-spawnRange,spawnRange);
        // float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        // Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for(int i = 0;i< enemiesToSpawn;i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 ){

            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

    }
}
