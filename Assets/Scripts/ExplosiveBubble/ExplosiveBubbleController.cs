using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;


public class ExplosiveAttribute : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubble moves upward
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minScale = 0.7f; // Minimum scale for bubble size
    public float maxScale = 1.3f; // Maximum scale
    public CircleCollider2D circleCollider;
    private bool clicked = false;
    private List <GameObject> objInRadius = new List<GameObject>();
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
        clicked = true;
        for(int i = objInRadius.Count-1; i > 0; i--){
            Debug.Log(i);
            Debug.Log(objInRadius.Count);

            if (objInRadius[i].tag == "Bubble")
            {
                GameManager.Instance.AddScore(10);
            }
            else if (objInRadius[i].tag == "GoldenBubble")
            {
                GameManager.Instance.AddScore(20);
            }
            else if (objInRadius[i].tag == "PurpleBubble")
            {
                GameManager.Instance.AddScore(-50);
            }
           
            Destroy(objInRadius[i]);
        }
        objInRadius.Clear();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        objInRadius.Add(other.gameObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        objInRadius.Remove(other.gameObject);
    }

    // Update is called once per frame
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
