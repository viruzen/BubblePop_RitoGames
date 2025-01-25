using UnityEngine;

public class FishGuy : MonoBehaviour
{
    private float _elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > 2.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
