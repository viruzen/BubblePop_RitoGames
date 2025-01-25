using System.Collections;
using UnityEngine;

public class DisplayImg : MonoBehaviour
{
    public float displayTime = 3f; // Time in seconds to display the image

    void Start()
    {
        // Start the coroutine to hide the image after the display time
        StartCoroutine(HideAfterSeconds());
    }

    private IEnumerator HideAfterSeconds()
    {
        // Wait for the specified display time
        yield return new WaitForSeconds(displayTime);

        // Disable the GameObject
        gameObject.SetActive(false);
    }
}
