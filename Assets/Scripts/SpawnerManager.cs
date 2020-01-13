using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 targetPosition;
    public float spawnPositionDeviation = 5;
    public float movementSpeed = 5;
    public float triggerDistance = 3;
    public int numberOfObjectsToSpawnPerWave = 4;
    public float delayBetweenWavesInS = 30;
    public float delayBetweenSpawnsInS = 3;
    
    private Spawner[] spawners;

    private int nextSpawnerIndex;
    private int objectsLeftToSpawn;
    
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();

        StartWave();
    }

    private void StartWave()
    {
        nextSpawnerIndex = 0;
        objectsLeftToSpawn = numberOfObjectsToSpawnPerWave;

        SpawnNextObject();
    }

    private void SpawnNextObject()
    {
        GameObject gameObject = Instantiate(objectToSpawn, spawners[nextSpawnerIndex].transform);
        gameObject.transform.Translate(transform.right * UnityEngine.Random.Range(-spawnPositionDeviation, spawnPositionDeviation));
        Attack attack = gameObject.AddComponent<Attack>();
        attack.targetPosition = targetPosition;
        attack.movementSpeed = movementSpeed;
        attack.triggerDistance = triggerDistance;

        nextSpawnerIndex = UnityEngine.Random.Range(0, spawners.Length);

        if (--objectsLeftToSpawn > 0)
        {
            Timer.Register(delayBetweenSpawnsInS, SpawnNextObject);
        }
        else
        {
            Timer.Register(delayBetweenWavesInS, StartWave);
        }
    }
}
