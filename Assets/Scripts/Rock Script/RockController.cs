using UnityEngine;

public class RockController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the rock falls
    public int lifePenalty = 1; // Number of lives lost if the rock is clicked

    private void Update()
    {
        // Move the rock downward
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destroy the rock if it goes off-screen
        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Deduct lives and destroy the rock
        if (GameManager.Instance != null)
        {
           // GameManager.Instance.LoseLife(lifePenalty);
            Debug.Log("Rock clicked! Player loses " + lifePenalty + " life.");
        }

        Destroy(gameObject);
    }
}
