using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine;
//namespace Scripts.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    private float Score;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public float HighScore;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Image slider;
    [SerializeField] private float timeLimit = 60.0f;



    float time;
    float multiplierFactor;

    private void OnEnable()
    {

    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged.AddListener(UpdateScore);
        }
        scoreText.text = "Score: 0";


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


        if (PlayerPrefs.GetFloat("HighScore") < Score)
        {
            PlayerPrefs.SetFloat("HighScore", HighScore);
            HighScore = Score;
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore");
        }

        highScoreText.text = HighScore.ToString();
        
    }

    private void UpdateScore(int newScore)
    {
        Score += newScore;
        scoreText.text = "Score: " + newScore;
    }
}