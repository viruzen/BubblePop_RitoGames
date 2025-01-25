using UnityEngine;

public class ExplosiveBubbleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject explosiveBubblePrefab; 
    public float spawnInterval = 10f; 
    public float minX = -5f, maxX = 5f; 

    private float nextSpawnTime; 

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set the initial spawn time
    }

    void Update()
    {
        
        if (Time.time >= nextSpawnTime)
        {
            SpawnGoldenBubble();
            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
        }
    }

    void SpawnGoldenBubble()
    {
        if (GameObject.FindGameObjectsWithTag("ExplosiveBubble").Length < 3) // Limit of bubbles
        {
            if (explosiveBubblePrefab == null)
            {
                Debug.LogError("Explosive Bubble Prefab is not assigned!");
                return;
            }

            // Generate a random position for the golden bubble
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

            // Instantiate the explosive bubble
            Instantiate(explosiveBubblePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Explosive bubble spawned!");
        }
    }
}
