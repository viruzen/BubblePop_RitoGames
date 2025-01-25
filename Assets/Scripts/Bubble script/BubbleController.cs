using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves upward
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minScale = 0.7f; // Minimum scale for bubble size
    public float maxScale = 1.3f; // Maximum scale
    void Update()
    {
        // Move the bubble upwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Assign a random size (scale)
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1f);

        // Destroy the bubble if it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Destroy bubble when clicked
        Destroy(gameObject);
    }

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
