using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D cursorClickTecture;

    private Vector2 cursorHotspot;
    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture,cursorHotspot, CursorMode.Auto);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorClickTecture, cursorHotspot, CursorMode.Auto);
            print("Click");
        }

        else if (Input.GetMouseButtonUp(0)){
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }
    }
}
