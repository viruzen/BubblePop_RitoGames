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
        [SerializeField] private TextMeshProUGUI timeText;
        private float _elapsedTime;
       
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
            _elapsedTime = 0.0f;
        }
        
        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            timeText.text = _elapsedTime.ToString("0.00");
            
        }

        private void UpdateScore(int newScore)
        {
            scoreText.text = "Score: "+newScore;
        }
        
    }
}
