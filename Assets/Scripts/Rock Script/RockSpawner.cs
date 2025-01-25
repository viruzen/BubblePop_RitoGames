using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab; // Drag your Rock prefab here in the Inspector
    public float spawnIntervalMin = 5f; // Minimum time between rock spawns
    public float spawnIntervalMax = 10f; // Maximum time between rock spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning rocks

    private float nextSpawnTime; // Time until the next rock spawns

    void Start()
    {
        ScheduleNextRockSpawn();
    }

    void Update()
    {
        // Spawn a rock when it's time
        if (Time.time >= nextSpawnTime)
        {
            SpawnRock();
            ScheduleNextRockSpawn();
        }
    }

    void SpawnRock()
    {
        if (rockPrefab == null)
        {
            Debug.LogError("Rock Prefab is not assigned!");
            return;
        }

        // Generate a random position for the rock at the bottom of the screen
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

        // Instantiate the rock
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Rock spawned!");
    }

    void ScheduleNextRockSpawn()
    {
        // Randomize the interval for the next spawn
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
