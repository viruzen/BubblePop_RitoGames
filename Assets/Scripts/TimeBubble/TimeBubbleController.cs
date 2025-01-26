using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TimeBubbleController : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves upward
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minScale = 0.7f; // Minimum scale for bubble size
    public float maxScale = 1.3f; // Maximum scale

    private float fixedDeltaTime;
    bool Clicked; 



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
    IEnumerator SlowTimeScale()
    {

        // Slow down the time
        Time.timeScale = 0.1f;
        float timePassed = 0.0f;

        // Wait for the specified duration
        while (timePassed < 5.0f)
        {
            timePassed += Time.unscaledDeltaTime;  // Increase time by unscaled time

            yield return null;
        }
        // Restore the time scale to normal
        Time.timeScale = 1.0f;
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
