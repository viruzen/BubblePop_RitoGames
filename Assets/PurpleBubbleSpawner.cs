using UnityEngine;

public class PurpleBubbleSpawner : MonoBehaviour
{
    public GameObject purpleBubblePrefab; // Drag the Purple Bubble prefab here in the Inspector
    public float spawnInterval = 10f; // Time interval before spawning a purple bubble
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning purple bubbles

    private float nextSpawnTime; // Time until the next purple bubble spawns

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set the initial spawn time
    }

    void Update()
    {
        // Check if it's time to spawn the next purple bubble
        if (Time.time >= nextSpawnTime)
        {
            SpawnPurpleBubble();
            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
        }
    }

    void SpawnPurpleBubble()
    {
        if (purpleBubblePrefab == null)
        {
            Debug.LogError("Purple Bubble Prefab is not assigned!");
            return;
        }

        // Generate a random position for the purple bubble
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0); // Spawn below the screen

        // Instantiate the purple bubble
        Instantiate(purpleBubblePrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Purple bubble spawned!");
    }
}