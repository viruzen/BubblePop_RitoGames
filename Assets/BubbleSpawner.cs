using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // Drag your Bubble prefab here in the Inspector
    public float spawnInterval = 1f; // Time between bubble spawns
    public float minX = -5f, maxX = 5f; // Horizontal range for spawning bubbles

    void Start()
    {
        // Start spawning bubbles repeatedly
        InvokeRepeating(nameof(SpawnBubble), 1f, spawnInterval);
    }

    void SpawnBubble()
    {
        if (GameObject.FindGameObjectsWithTag("Bubble").Length < 20) // Limit to 50 bubbles
        {
            // Generate a random position within the defined range
            float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

        // Instantiate a single bubble
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // Add random color to the bubble
        if (bubble.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }
        }
}
