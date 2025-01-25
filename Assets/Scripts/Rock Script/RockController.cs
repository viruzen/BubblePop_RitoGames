using UnityEngine;

public class RockController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the rock moves upward

    private void Update()
    {
        // Move the rock upward
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Destroy the rock if it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Set score to 0 and destroy the rock
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(-GameManager.Instance.GetScore()); // Reset the score to 0
            Debug.Log("Rock clicked! Score reset to 0.");
        }

        Destroy(gameObject);
    }
}
