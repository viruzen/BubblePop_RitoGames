using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
namespace Scrpits.UI
{
    public class UIManager : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

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

            scoreText.text = "score: 0";

            multiplierFactor = 1.0f / timeLimit;
            time = 60.0f;
            slider.fillAmount = time * multiplierFactor;
        }
        
        private void Update()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timerText.text = Mathf.CeilToInt(time).ToString();
                slider.fillAmount = time * multiplierFactor;
            }
        }

        private void UpdateScore(int newScore)
        {
            scoreText.text = "Score: "+newScore;
        }
        
    }
}
