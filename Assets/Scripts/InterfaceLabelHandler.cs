using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InterfaceLabelHandler : MonoBehaviour
{
    [SerializeField] private Image[] intensityIcons;
    private Color32[] selectionColor = { new Color32(128, 128, 128, 128), new Color32(192, 192, 192, 128) };

    [SerializeField] private Image colorIcon;
    private Color32[] yellowBlueColor = { new Color32(255, 255, 0, 192), new Color32(0, 0, 255, 192) };

    [SerializeField] private Image tfaIcon;
    [SerializeField] private Sprite[] onOffSprites;

    [SerializeField] private Image uniformityIcon;
    [SerializeField] private Sprite[] highLowTexture;

    public void UpdateInterfaceLabel(float sliderValue)
    {
        int sliderIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name.Split('_')[1]);

        switch (sliderIndex)
        {
            case 1:
                this.UpdateIntensityLabel((int)sliderValue);
                break;
            case 2:
                this.UpdateColorLabel((int)sliderValue);
                break;
            case 3:
                this.UpdateFacadeLabel((int)sliderValue);
                break;
            case 4:
                this.UpdateUniformityLabel((int)sliderValue);
                break;
        }
    }

    private void UpdateIntensityLabel(int sliderValue)
    {
        foreach (Image icon in this.intensityIcons)
        {
            icon.color = this.selectionColor[0];
            icon.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        }
        this.intensityIcons[sliderValue - 1].color = this.selectionColor[1];
        this.intensityIcons[sliderValue - 1].GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
    }

    private void UpdateColorLabel(int sliderValue)
    {
        this.colorIcon.color = this.yellowBlueColor[sliderValue - 1];
    }

    private void UpdateFacadeLabel(int sliderValue)
    {
        this.tfaIcon.sprite = this.onOffSprites[sliderValue - 1];
    }

    private void UpdateUniformityLabel(int sliderValue)
    {
        this.uniformityIcon.sprite = this.highLowTexture[sliderValue - 1];
    }


}
