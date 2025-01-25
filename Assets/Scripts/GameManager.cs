using UnityEngine;
using UnityEngine.UI; // Required for UI
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();

    
    // Game variables
    private int score = 0; // Tracks player score
    public Text scoreText; // Assign this in the Inspector
    public Text livesText; // Assign this in the Inspector
    private int _score;
    public GameObject gameOverPanel; // Assign this in the Inspector for Game Over UI


    void Awake()
    {
        // Ensure there s only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize UI at the start
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        /*score += amount;
        Debug.Log("Score: " + score); // Logs score to console for now
        UpdateUI();*/

        _score += amount;
        OnScoreChanged.Invoke(_score);
    }
    public int GetScore()
    {
        return score;
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Restarting the game...");
        // Optionally reload the scene or handle game over logic
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        //    // Optionally, stop the game or do any other game over logic
        //    Time.timeScale = 0; // Stops the game (pause effect)
        //    Debug.Log("Game Over! Restarting the game...");
    }

    // Update the UI elements with the latest score and lives
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

    }

}
