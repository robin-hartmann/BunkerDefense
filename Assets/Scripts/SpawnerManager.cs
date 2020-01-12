using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 targetPosition;
    public float spawnPositionDeviation = 5;
    public float movementSpeed = 5;
    public float triggerDistance = 3;
    public int numberOfObjectsToSpawnPerWave = 4;
    public double delayBetweenWavesInMs = 30000;
    public double delayBetweenSpawnsInMs = 3000;

    private readonly ConcurrentQueue<Action> mainThreadQueue = new ConcurrentQueue<Action>();
    private Spawner[] spawners;
    private Timer waveTimer;
    private Timer spawnTimer;

    private int nextSpawnerIndex;
    private int objectsLeftToSpawn;
    
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        
        waveTimer = new Timer(delayBetweenWavesInMs);
        spawnTimer = new Timer(delayBetweenSpawnsInMs);
        waveTimer.Elapsed += StartWave;
        spawnTimer.Elapsed += SpawnNextObject;
        waveTimer.AutoReset = false;
        spawnTimer.AutoReset = false;

        StartWave(null, null);
    }

    void Update()
    {
        if (!mainThreadQueue.IsEmpty)
        {
            Action action;
            while (mainThreadQueue.TryDequeue(out action))
            {
                action.Invoke();
            }
        }
    }

    private void StartWave(object sender, ElapsedEventArgs e)
    {
        nextSpawnerIndex = 0;
        objectsLeftToSpawn = numberOfObjectsToSpawnPerWave;

        SpawnNextObject(null, null);
    }

    private void SpawnNextObject(object sender, ElapsedEventArgs e)
    {
        mainThreadQueue.Enqueue(() => {
            GameObject gameObject = Instantiate(objectToSpawn, spawners[nextSpawnerIndex].transform);
            gameObject.transform.Translate(transform.right * UnityEngine.Random.Range(-spawnPositionDeviation, spawnPositionDeviation));
            Attack attack = gameObject.AddComponent<Attack>();
            attack.targetPosition = targetPosition;
            attack.movementSpeed = movementSpeed;
            attack.triggerDistance = triggerDistance;

            nextSpawnerIndex = UnityEngine.Random.Range(0, spawners.Length);

            if (--objectsLeftToSpawn > 0)
            {
                spawnTimer.Start();
            }
            else
            {
                waveTimer.Start();
            }
        });
    }
}
