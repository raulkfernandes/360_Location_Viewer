using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InterfaceSelectionHandler : MonoBehaviour
{
    private byte selectedImageAlpha = 128;
    private byte selectedFontAlpha = 255;
    private TMPro.FontStyles selectedFontStyle = TMPro.FontStyles.Bold;

    private byte deselectedImageAlpha = 64;
    private byte deselectedFontAlpha = 128;
    private TMPro.FontStyles deselectedFontStyle = TMPro.FontStyles.Normal;

    private GameObject currentSelectedSlider;

    //  Chamado pelo 'EventTrigger: Select' de cada 'Slider_X':
    public void UpdateInterfaceOnSelect(BaseEventData eventData)
    {
        this.currentSelectedSlider = EventSystem.current.currentSelectedGameObject;
        this.UpdateComponents(this.selectedImageAlpha, this.selectedFontAlpha, this.selectedFontStyle);
    }

    //  Chamado pelo 'EventTrigger: Deselect' de cada 'Slider_X':
    public void UpdateInterfaceOnDeselect(BaseEventData eventData)
    {
        this.UpdateComponents(this.deselectedImageAlpha, this.deselectedFontAlpha, this.deselectedFontStyle);
    }

    //  Altera aparência dos componentes de cada 'Menu Items > Item_X':
    private void UpdateComponents(byte imageAlpha, byte fontAlpha, TMPro.FontStyles fontStyle)
    {
        Transform selectedSliderParent = EventSystem.current.currentSelectedGameObject.transform.parent;
        selectedSliderParent.GetComponentInChildren<Image>().color = new Color32(192, 192, 192, imageAlpha);
        selectedSliderParent.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, fontAlpha);
        selectedSliderParent.GetComponentInChildren<TextMeshProUGUI>().fontStyle = fontStyle;
    }

    //  Referência para a Slider que está com o foco de seleção:
    public GameObject GetCurrentSliderSelected()
    {
        return this.currentSelectedSlider;
    }
}