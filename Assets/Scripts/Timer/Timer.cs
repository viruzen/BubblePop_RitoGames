using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public Image slider;
    public float timeLimit = 60.0f;

    float time;
    float multiplierFactor;
    //bool startTimer;

    public void StartTimer()
    {
        multiplierFactor = 1.0f / timeLimit;
        time = 60.0f;
        slider.fillAmount = time * multiplierFactor;
    }

    private void Update()
    {
        if (time >1.0f)
        {
            time -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(time).ToString();
            slider.fillAmount = time * multiplierFactor;
        }
       
            //Load the scoreboard
            SceneManager.LoadSceneAsync("GameOver");
            
        

    }
}
