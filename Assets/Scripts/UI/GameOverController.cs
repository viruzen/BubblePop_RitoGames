using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelCanvasGroup;
    private float _elapedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelCanvasGroup.alpha = 0f;          // Makes the panel invisible
        panelCanvasGroup.interactable = false; // Disables interaction
        panelCanvasGroup.blocksRaycasts = false; // Disables input blocking
        _elapedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_elapedTime > 60.0f)
        {
            panelCanvasGroup.alpha = 100f;          // Makes the panel invisible
            panelCanvasGroup.interactable = true; // Disables interaction
            panelCanvasGroup.blocksRaycasts = true; // Disables input blocking
        }
        _elapedTime += Time.deltaTime;
    }
}
