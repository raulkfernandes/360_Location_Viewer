using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InterfaceLabelHandler : MonoBehaviour
{
    [SerializeField] private Image[] intensityIcons;
    private Color32[] selectionColor = { new Color32(128, 128, 128, 128), new Color32(192, 192, 192, 128) };

    [SerializeField] private Image colorIcon;
    private Color32[] yellowBlueColor = { new Color32(192, 192, 0, 255), new Color32(0, 0, 192, 255) };

    [SerializeField] private Image tfStatusIcon;
    [SerializeField] private Sprite[] onOffSprites;

    [SerializeField] private Image uniformityIcon;
    [SerializeField] private Sprite[] highLowTexture;

    //  Chamado pelo 'EventTrigger: On Value Changed' de cada Slider_X para alterar os Icons usados como legenda em 'Selection_Menu':
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
                this.UpdateTFStatusLabel((int)sliderValue);
                break;
            case 4:
                this.UpdateUniformityLabel((int)sliderValue);
                break;
        }
    }

    //  Altera aparência dos Icons que representam a intensidade da iluminação do cenário:
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

    //  Altera aparência do Icon que representa a cor da iluminação do cenário:
    private void UpdateColorLabel(int sliderValue)
    {
        this.colorIcon.color = this.yellowBlueColor[sliderValue - 1];
    }

    //  Altera aparência do Icon que representa o status da iluminação de árvores/fachadas do cenário:
    private void UpdateTFStatusLabel(int sliderValue)
    {
        this.tfStatusIcon.sprite = this.onOffSprites[sliderValue - 1];
    }

    //  Altera aparência do Icon que representa a uniformidade da iluminação do cenário:
    private void UpdateUniformityLabel(int sliderValue)
    {
        this.uniformityIcon.sprite = this.highLowTexture[sliderValue - 1];
    }


}
