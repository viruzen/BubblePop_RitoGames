using UnityEngine;

public class PurpleBubbleController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves upward
    public int scorePenalty = 50; // Score lost when the purple bubble is clicked

    void Start()
    {
        // Assign a random speed for the purple bubble (if you want randomness)
        speed = Random.Range(1f, 3f);
    }

    void Update()
    {
        // Move the bubble upwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Destroy the bubble if it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Apply score penalty (damage to the score) when clicked
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(-scorePenalty); // Deduct score
            Debug.Log("Purple bubble clicked! Player loses " + scorePenalty + " points.");
        }

        // Destroy the purple bubble
        Destroy(gameObject);
    }
}