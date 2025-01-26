using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    public void StartGame(){
        SceneManager.LoadSceneAsync("Game");    
    }

    private void Update()
    {
        highScoreText.text = " " + PlayerPrefs.GetFloat("HighScore");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
