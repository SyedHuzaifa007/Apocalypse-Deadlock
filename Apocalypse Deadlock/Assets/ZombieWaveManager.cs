using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaveManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int numberOfZombiesInWave = 5;
    public float timeBetweenSpawns = 2.0f;

    private Transform[] spawnPoints;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnZombieWave());
    }

    IEnumerator SpawnZombieWave()
    {
        for (int i = 0; i < numberOfZombiesInWave; i++)
        {
            int randomSpawnIndex = Random.Range(1, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;

            GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
