using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hospot = new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hospot, CursorMode.Auto);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hospot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hospot, CursorMode.Auto);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorReload, hospot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(cursorNormal, hospot, CursorMode.Auto);
        }
    }
}
