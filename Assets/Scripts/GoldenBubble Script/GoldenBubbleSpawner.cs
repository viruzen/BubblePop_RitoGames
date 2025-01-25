using UnityEngine;

public class GoldenBubbleSpawner : MonoBehaviour
{
    public GameObject goldenBubblePrefab; // Drag the Golden Bubble prefab here in the Inspector
    public float spawnIntervalMin = 10f; // Minimum time before a golden bubble spawns
    public float spawnIntervalMax = 20f; // Maximum time before a golden bubble spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning golden bubbles

    private float nextSpawnTime; // Time until the next golden bubble spawns

    private bool isSpawning = false;



    //    void Start()
    //    {
    //        ScheduleNextGoldenBubble();
    //    }

    //    void Update()
    //    {
    //        if (Time.time >= nextSpawnTime)
    //        {
    //            SpawnGoldenBubble();
    //            ScheduleNextGoldenBubble();
    //        }
    //    }

    //    void SpawnGoldenBubble()
    //    {
    //        if (goldenBubblePrefab == null)
    //        {
    //            Debug.LogError("Golden Bubble Prefab is not assigned!");
    //            return;
    //        }

    //        // Generate a random position for the golden bubble
    //        float randomX = Random.Range(minX, maxX);
    //        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

    //        // Instantiate the golden bubble
    //        Instantiate(goldenBubblePrefab, spawnPosition, Quaternion.identity);
    //        Debug.Log("Golden bubble spawned!");
    //    }

    //    void ScheduleNextGoldenBubble()
    //    {
    //        // Set the time for the next golden bubble to spawn
    //        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    //    }
    //}

    public void StartSpawning()
    {
        if (isSpawning) return;
        Debug.Log("[GoldenBubbleSpawner] Starting to spawn golden bubbles.");
        isSpawning = true;
        SpawnGoldenBubble();
    }

    public void StopSpawning()
    {
        if (!isSpawning) return;
        Debug.Log("[GoldenBubbleSpawner] Stopping golden bubble spawning.");
        isSpawning = false;
        CancelInvoke(nameof(SpawnGoldenBubble));
    }

    void SpawnGoldenBubble()
    {
        if (!isSpawning || goldenBubblePrefab == null) return;

        int goldenBubbleCount = GameObject.FindGameObjectsWithTag("GoldenBubble").Length;
        if (goldenBubbleCount < 5)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);
            Instantiate(goldenBubblePrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"[GoldenBubbleSpawner] Golden bubble spawned at {spawnPosition}.");
        }
        else
        {
            Debug.Log("[GoldenBubbleSpawner] Golden bubble limit reached, no spawn.");
        }

        // Schedule the next spawn with a randomized interval
        float nextSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke(nameof(SpawnGoldenBubble), nextSpawnInterval);
        Debug.Log($"[GoldenBubbleSpawner] Next spawn in {nextSpawnInterval} seconds.");
    }
}


