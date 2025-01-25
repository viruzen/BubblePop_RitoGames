using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();

    private int _score;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        _score = 0;
    }
    
    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged.Invoke(_score);
    }
}
