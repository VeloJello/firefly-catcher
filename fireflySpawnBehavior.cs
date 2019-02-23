using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflySpawnBehavior : MonoBehaviour
{
    public GameObject firefly;

    public int maxFlies;
    public int flies;

    public float spawnDelayMin;
    public float spawnDelayMax;
    float spawnDelay;

    int spawnerCount;
    int currentSpawner;

    public Transform[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        flies = 0;
        spawnerCount = spawners.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //constantly setting location in spawners array to something random
        currentSpawner = Random.Range(0, 4);

        flies = GameObject.FindGameObjectsWithTag("Firefly").Length;

        if (flies < maxFlies)
        {
            Instantiate(firefly, spawners[currentSpawner].position, spawners[currentSpawner].rotation);
            flies++;
            allTracker.scoreValue++;
        }
    }
}
