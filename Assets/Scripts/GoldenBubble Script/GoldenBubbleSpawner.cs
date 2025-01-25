using UnityEngine;

public class GoldenBubbleSpawner : MonoBehaviour
{
    public GameObject goldenBubblePrefab; // Drag the Golden Bubble prefab here in the Inspector
    public float spawnInterval = 5f; // Fixed time before a golden bubble spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning golden bubbles

    private float nextSpawnTime; // Time until the next golden bubble spawns

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set the initial spawn time
    }

    void Update()
    {
        // Check if the time has passed for spawning the next golden bubble
        if (Time.time >= nextSpawnTime)
        {
            SpawnGoldenBubble();
            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
        }
    }

    void SpawnGoldenBubble()
    {
        if (GameObject.FindGameObjectsWithTag("GoldenBubble").Length < 5) // Limit of bubbles
        {
            if (goldenBubblePrefab == null)
            {
                Debug.LogError("Golden Bubble Prefab is not assigned!");
                return;
            }

            // Generate a random position for the golden bubble
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

            // Instantiate the golden bubble
            Instantiate(goldenBubblePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Golden bubble spawned!");
        }
    }
}
