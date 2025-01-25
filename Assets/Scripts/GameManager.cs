using UnityEngine;
using UnityEngine.UI; // Required for UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    private int score = 0;
    public int playerLives = 3; 

    public Text scoreText; // Assign this in the Inspector
    public Text livesText; // Assign this in the Inspector

    public GameObject gameOverPanel;
    void Awake()
    {
        // Ensure there’s only one instance of GameManager
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
        score += amount;
        Debug.Log("Score: " + score); // Logs score to console for now
        UpdateUI();
    }

    public void LoseLife(int amount)
    {
        playerLives -= amount;
        Debug.Log("Lives Remaining: " + playerLives);
        UpdateUI();

        if (playerLives <= 0)
        {
            GameOver();
        }
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

        if (livesText != null)
            livesText.text = "Lives: " + playerLives;
    }

}
