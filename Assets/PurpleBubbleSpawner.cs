using UnityEngine;

public class PurpleBubbleSpawner : MonoBehaviour
{
    public GameObject purpleBubblePrefab; // Drag the Purple Bubble prefab here in the Inspector
    public float spawnIntervalMin = 5f; // Minimum time between rock spawns
    public float spawnIntervalMax = 10f;
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning purple bubbles

    private float nextSpawnTime; // Time until the next purple bubble spawns
    private bool isSpawning = false;


    //    void Start()
    //    {
    //        nextSpawnTime = Time.time + spawnInterval; // Set the initial spawn time
    //    }

    //    void Update()
    //    {
    //        // Check if it's time to spawn the next purple bubble
    //        if (Time.time >= nextSpawnTime)
    //        {
    //            SpawnPurpleBubble();
    //            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
    //        }
    //    }

    //    void SpawnPurpleBubble()
    //    {
    //        if (purpleBubblePrefab == null)
    //        {
    //            Debug.LogError("Purple Bubble Prefab is not assigned!");
    //            return;
    //        }

    //        // Generate a random position for the purple bubble
    //        float randomX = Random.Range(minX, maxX);
    //        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0); // Spawn below the screen

    //        // Instantiate the purple bubble
    //        Instantiate(purpleBubblePrefab, spawnPosition, Quaternion.identity);
    //        Debug.Log("Purple bubble spawned!");
    //    }
    //}
    
    
    public void StartSpawning()
    {
        if (isSpawning) return;
        Debug.Log("[PurpleBubbleSpawner] Starting to spawn purple bubbles.");
        isSpawning = true;
        SpawnPurpleBubble();
    }

    public void StopSpawning()
    {
        if (!isSpawning) return;
        Debug.Log("[PurpleBubbleSpawner] Stopping purple bubble spawning.");
        isSpawning = false;
        CancelInvoke(nameof(SpawnPurpleBubble));
    }

    void SpawnPurpleBubble()
    {
        if (!isSpawning || purpleBubblePrefab == null) return;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);
        Instantiate(purpleBubblePrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"[PurpleBubbleSpawner] Purple bubble spawned at {spawnPosition}.");

        // Schedule the next spawn with a randomized interval
        float nextSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke(nameof(SpawnPurpleBubble), nextSpawnInterval);
        Debug.Log($"[PurpleBubbleSpawner] Next spawn in {nextSpawnInterval} seconds.");
    }
}


