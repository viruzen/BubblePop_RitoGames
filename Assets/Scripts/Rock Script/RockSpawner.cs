using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab; // Drag your Rock prefab here in the Inspector
    public float spawnIntervalMin = 5f; // Minimum time between rock spawns
    public float spawnIntervalMax = 10f; // Maximum time between rock spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning rocks

    private float nextSpawnTime; // Time until the next rock spawns

    private bool isSpawning = false;

    //    void Start()
    //    {
    //        ScheduleNextRockSpawn();
    //    }

    //    void Update()
    //    {
    //        // Spawn a rock when it's time
    //        if (Time.time >= nextSpawnTime)
    //        {
    //            SpawnRock();
    //            ScheduleNextRockSpawn();
    //        }
    //    }

    //    void SpawnRock()
    //    {
    //        if (rockPrefab == null)
    //        {
    //            Debug.LogError("Rock Prefab is not assigned!");
    //            return;
    //        }

    //        // Generate a random position for the rock at the bottom of the screen
    //        float randomX = Random.Range(minX, maxX);
    //        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

    //        // Instantiate the rock
    //        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    //        Debug.Log("Rock spawned!");
    //    }

    //    void ScheduleNextRockSpawn()
    //    {
    //        // Randomize the interval for the next spawn
    //        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    //    }
    //}

    public void StartSpawning()
    {
        if (isSpawning) return;
        Debug.Log("[RockSpawner] Starting to spawn rocks.");
        isSpawning = true;
        SpawnRock();
    }

    public void StopSpawning()
    {
        if (!isSpawning) return;
        Debug.Log("[RockSpawner] Stopping rock spawning.");
        isSpawning = false;
        CancelInvoke(nameof(SpawnRock));
    }

    void SpawnRock()
    {
        if (!isSpawning || rockPrefab == null) return;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"[RockSpawner] Rock spawned at {spawnPosition}.");

        // Schedule the next spawn with a randomized interval
        float nextSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke(nameof(SpawnRock), nextSpawnInterval);
        Debug.Log($"[RockSpawner] Next spawn in {nextSpawnInterval} seconds.");
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        Destroy(other.gameObject);
    }


}

