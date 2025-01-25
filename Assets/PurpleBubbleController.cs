using UnityEngine;

public class PurpleBubbleController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves
    public int scorePenalty = 50; // Score lost when the purple bubble is clicked
    
    void Start()
    {
        // Assign a random speed for the purple bubble (if you want randomness)
        speed = Random.Range(1f, 3f);
    }

    void Update()
    {
        // Move the bubble upwards (bottom to top)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Destroy the bubble if it goes off the top of the screen
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {

        GameManager.Instance.AddScore(-50);

        // Destroy the purple bubble
        Destroy(gameObject);
    }
}
