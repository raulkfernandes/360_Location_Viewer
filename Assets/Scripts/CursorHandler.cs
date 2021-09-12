using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] InterfaceSelectionHandler interfaceSelectionHandler;
    [SerializeField] private Texture2D sceneryCursorTexture;
    private Vector2 sceneryCursorHotspot;

    //  Altera o cursor padrão para indicar navegação no cenário:
    private void Awake()
    {
        this.sceneryCursorHotspot = new Vector2(sceneryCursorTexture.width / 2, sceneryCursorTexture.height / 2);
    }

    //  Chamado pelo 'EventTrigger: Pointer Enter' de 'Selection_Menu':
    public void SetUICursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    //  Chamado pelo 'EventTrigger: Pointer Exit' de 'Selection_Menu':
    public void SetSceneryCursor()
    {
        Cursor.SetCursor(this.sceneryCursorTexture, this.sceneryCursorHotspot, CursorMode.ForceSoftware);
    }

    //  Chamado pelo 'EventTrigger: Pointer Down' de 'Selection_Menu':
    public void ResetObjectSelection()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(this.interfaceSelectionHandler.GetCurrentSliderSelected());
        }
    }
}
