using UnityEngine;

public class GoldenBubbleController : MonoBehaviour
{
    public float minSpeed = 1f; // Minimum upward speed
    public float maxSpeed = 3f; // Maximum upward speed
    private float speed;

    public int bonusPoints = 10; // Points awarded for clicking a golden bubble

    void Start()
    {
        // Assign a random upward speed
        speed = Random.Range(minSpeed, maxSpeed);
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
        // Add bonus points to the score and destroy the bubble
        GameManager.Instance.AddScore(bonusPoints);
        Debug.Log("Golden bubble clicked! Bonus points: " + bonusPoints);

        ////Play a sound
        ////AudioSource.PlayClipAtPoint(yourAudioClip, transform.position);

        Destroy(gameObject);
    }
}
