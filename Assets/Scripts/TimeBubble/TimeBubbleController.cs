using System.Collections;


using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
//using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TimeBubbleController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves upward
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minScale = 0.7f; // Minimum scale for bubble size
    public float maxScale = 1.3f; // Maximum scale
    public Collider2D clickBox; 
    public SpriteRenderer spRenderer;

    private float fixedDeltaTime;
     



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
    IEnumerator SlowTimeScale()
    {
        clickBox.enabled = false;
        spRenderer.enabled = false ;
        // Slow down the time
        Time.timeScale = 0.1f;
        SoundManager.instance.SetPitch(Time.timeScale);
        float timePassed = 0.0f;

        // Wait for the specified duration
        while (timePassed < 5.0f)
        {
            timePassed += Time.unscaledDeltaTime;  // Increase time by unscaled time

            yield return null;
        }
        // Restore the time scale to normal
        Time.timeScale = 1.0f;
        SoundManager.instance.ResetPitch();
        Destroy(gameObject);

    }
    private void OnMouseDown()
    {
        //GameManager.Instance.AddScore(10);
        // Destroy bubble when clicked
        
       
       StartCoroutine(SlowTimeScale()); 

    }

    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
