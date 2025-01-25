using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab; // Drag the Rock prefab here in the Inspector
    public float spawnInterval = 5f; // Time interval before spawning a rock
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning rocks

    private float nextSpawnTime; // Time until the next rock spawns

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set the initial spawn time
    }

    void Update()
    {
        // Check if it's time to spawn the next rock
        if (Time.time >= nextSpawnTime)
        {
            SpawnRock();
            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
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
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0); // Spawn below the screen

        // Instantiate the rock
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Rock spawned!");
    }
}
