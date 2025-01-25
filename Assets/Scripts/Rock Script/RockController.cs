using UnityEngine;

public class RockController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the rock moves upward
    public int lifePenalty = 1; // Number of lives lost if the rock is clicked

    private void Update()
    {
        // Move the rock upward (change the direction to Vector2.up)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Destroy the rock if it goes off-screen (if it moves above the screen)
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Deduct lives and destroy the rock when clicked
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife(lifePenalty);
            Debug.Log("Rock clicked! Player loses " + lifePenalty + " life.");
        }

        Destroy(gameObject);
    }
}
