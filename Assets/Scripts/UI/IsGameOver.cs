using UnityEngine;

public class IsGameOver : MonoBehaviour
{
    private float _elapedTime;
    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _elapedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ACTIVE");
        if (_elapedTime > 60.0f)
        {
            this.gameObject.SetActive(true);
        }
        _elapedTime += Time.deltaTime;
    }
}
