using UnityEngine;

public class GoldenBubbleController : MonoBehaviour
{
    public float minSpeed = 1f; // Minimum upward speed
    public float maxSpeed = 3f; // Maximum upward speed
    private float speed;
    public float minScale = 0.7f; // Minimum scale for bubble size
    public float maxScale = 1.3f; // Maximum scale

    public int bonusPoints = 10; // Points awarded for clicking a golden bubble

    [SerializeField] private AudioClip Golden_bb;

    void Start()
    {
        // Assign a random upward speed
        speed = Random.Range(minSpeed, maxSpeed);
    }

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

        ////Play a sound
        ////AudioSource.PlayClipAtPoint(yourAudioClip, transform.position);
        SoundManager.instance.PlaySound(Golden_bb);
        GameManager.Instance.AddScore(20);

        Destroy(gameObject);
    }
}
