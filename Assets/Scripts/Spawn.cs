using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    private float spawnRangeX = 9;
    private float spawnPosZ = 380;
    private float startDelay = 1;
    private float repeatRate = 1;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver)
            return;
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        Vector3 spawnPros = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(obstaclePrefab[obstacleIndex], spawnPros, obstaclePrefab[obstacleIndex].transform.rotation);
    }
}