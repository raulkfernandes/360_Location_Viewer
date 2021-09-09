using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] InterfaceSelectionHandler interfaceSelectionHandler;
    [SerializeField] private Texture2D sceneryCursor;
    private Vector2 sceneryCursorHotspot;

    private void Start()
    {
        this.sceneryCursorHotspot = new Vector2(sceneryCursor.width / 2, sceneryCursor.height / 2);
        this.SetSceneryCursor();
    }

    public void SetUICursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void SetSceneryCursor()
    {
        Cursor.SetCursor(this.sceneryCursor, this.sceneryCursorHotspot, CursorMode.Auto);
    }

    public void ResetObjectSelection()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(this.interfaceSelectionHandler.GetCurrentSliderSelected());
        }
    }
}
