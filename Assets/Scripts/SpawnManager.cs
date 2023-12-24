using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject garbage;
    public GameObject coins;
    public GameObject sp_energy;

    public float maxX, minX, maxY, minY;
    public float obstacleTimeBetweenSpawn;
    public float itemsTimeBetweenSpawn;
    public float spTimeBetweenSpawn;

    private float obstacleSpawnTime ;
    private float itemsSpawnTime ;
    private float spSpawnTime ;

    // Update is called once per frame
    private void Update()
    {
        // if (Time.time > spawnTime)
        // {
        //     if (obstacle.tag == "Obstacle")
        //     {
        //         Spawn(obstacle);
        //         spawnTime = Time.time + obstacleTimeBetweenSpawn;
        //     }
        //     if (garbage.tag == "Garbage")
        //     {
        //         Spawn(garbage);
        //         spawnTime = Time.time + garbageTimeBetweenSpawn;
        //     }
        // }
        if (Time.time > obstacleSpawnTime)
        {
            Spawn(obstacle);
            obstacleSpawnTime = Time.time + obstacleTimeBetweenSpawn;
        }
        if (Time.time > itemsSpawnTime)
        {
            Spawn(garbage);
            Spawn(coins);
            itemsSpawnTime = Time.time + itemsTimeBetweenSpawn;
        }
        if (Time.time > spSpawnTime)
        {
            Spawn(sp_energy);
            spSpawnTime = Time.time + spTimeBetweenSpawn;
        }
    }

    private void Spawn(GameObject gameObject)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(gameObject, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
