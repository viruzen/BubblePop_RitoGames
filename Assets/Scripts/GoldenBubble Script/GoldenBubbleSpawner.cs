using UnityEngine;

public class GoldenBubbleSpawner : MonoBehaviour
{
    public GameObject goldenBubblePrefab; // Drag the Golden Bubble prefab here in the Inspector
    public float spawnIntervalMin = 10f; // Minimum time before a golden bubble spawns
    public float spawnIntervalMax = 20f; // Maximum time before a golden bubble spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning golden bubbles

    private float nextSpawnTime; // Time until the next golden bubble spawns

    void Start()
    {
        ScheduleNextGoldenBubble();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnGoldenBubble();
            ScheduleNextGoldenBubble();
        }
    }

    void SpawnGoldenBubble()
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

    void ScheduleNextGoldenBubble()
    {
        // Set the time for the next golden bubble to spawn
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
