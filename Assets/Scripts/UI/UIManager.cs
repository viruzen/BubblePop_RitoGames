using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
//namespace Scripts.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    private float Score;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private float HighScore;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Image slider;
    [SerializeField] private float timeLimit = 60.0f;



    float time;
    float multiplierFactor;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged.AddListener(UpdateScore);
        }
        


        multiplierFactor = 1.0f / timeLimit;
        time = 60.0f;
        slider.fillAmount = time * multiplierFactor;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            HighScore = 0;
        }
        scoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + HighScore;
    }

    private void Update()
    {
        //HighScore = PlayerPrefs.GetFloat("HighScore");
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(time).ToString();
            slider.fillAmount = time * multiplierFactor;
        }

        if (time <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (PlayerPrefs.GetFloat("HighScore") < Score)
        {
            PlayerPrefs.SetFloat("HighScore", HighScore);
            HighScore = Score;
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore");
        }

        highScoreText.text = "High Score: " + HighScore;
        
    }

    private void UpdateScore(int newScore)
    {
        Score += newScore;
        scoreText.text = "Score: " + newScore;
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}