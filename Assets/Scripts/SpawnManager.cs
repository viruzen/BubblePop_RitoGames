using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnSettings
    {
        public GameObject prefab;       // Prefab to spawn
        public float minInterval = 10f; // Minimum spawn interval
        public float maxInterval = 20f; // Maximum spawn interval
        public int maxActive = 5;       // Max active objects of this type
        public string tag;              // Tag for spawned objects
    }

    public List<SpawnSettings> spawnSettings; // List of spawner settings
    private Dictionary<string, float> nextSpawnTimes; // Tracks next spawn time for each type

    void Start()
    {
        nextSpawnTimes = new Dictionary<string, float>();

        foreach (var settings in spawnSettings)
        {
            if (settings.prefab == null || string.IsNullOrEmpty(settings.tag))
            {
                Debug.LogError($"[SpawnManager] Invalid settings for prefab: {settings.prefab}");
                continue;
            }

            // Initialize the next spawn time for each type
            nextSpawnTimes[settings.tag] = Time.time + Random.Range(settings.minInterval, settings.maxInterval);
        }
    }

    void Update()
    {
        foreach (var settings in spawnSettings)
        {
            if (!nextSpawnTimes.ContainsKey(settings.tag)) continue;

            // Check if it's time to spawn the next object
            if (Time.time >= nextSpawnTimes[settings.tag])
            {
                SpawnObject(settings);

                // Schedule the next spawn
                nextSpawnTimes[settings.tag] = Time.time + Random.Range(settings.minInterval, settings.maxInterval);
            }
        }
    }

    private void SpawnObject(SpawnSettings settings)
    {
        if (GameObject.FindGameObjectsWithTag(settings.tag).Length >= settings.maxActive)
        {
            Debug.Log($"[SpawnManager] Maximum active objects for tag '{settings.tag}' reached.");
            return;
        }

        // Generate a random spawn position
        float randomX = Random.Range(-5f, 5f); // Adjust as needed for your game
        Vector3 spawnPosition = new Vector3(randomX, -Camera.main.orthographicSize - 1, 0);

        // Instantiate the object
        Instantiate(settings.prefab, spawnPosition, Quaternion.identity);
        Debug.Log($"[SpawnManager] Spawned {settings.tag} at {spawnPosition}.");
    }
}