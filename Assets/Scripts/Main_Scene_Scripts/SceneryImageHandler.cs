using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneryImageHandler : MonoBehaviour
{
    [SerializeField] private Material insideOutMaterial;
    [SerializeField] private GameObject sphere;

    private Dictionary<int, string[]> imageHandler = new Dictionary<int, string[]>();
    private string intensity, color, tfStatus, uniformity;

    private Quaternion defaultRotation;
    private bool exceptionHandled = false;

    //  Preenche o Dictionary e define estado inicial do cenário:
    private void Awake()
    {
        this.InitializeImageHandlerDictionary();
        this.UpdateMaterialTexture(this.GetImagePathString());
        this.defaultRotation = this.sphere.transform.rotation;
    }

    //  Inicializa o Dictionary com todos os valores previstos para os arquivos de imagem:
    private void InitializeImageHandlerDictionary()
    {
        this.imageHandler.Add(1, new string[] { "2.5", "10", "20", "50" });
        this.imageHandler.Add(2, new string[] { "3000K", "6000K" });
        this.imageHandler.Add(3, new string[] { "OFF", "ON" });
        this.imageHandler.Add(4, new string[] { "LOW", "HIGH" });

        this.SetInitialValues();
    }

    //  Define valores iniciais para cada 'Slider_X':
    private void SetInitialValues()
    {
        this.intensity = this.imageHandler[1][0];
        this.color = this.imageHandler[2][0];
        this.tfStatus = this.imageHandler[3][0];
        this.uniformity = this.imageHandler[4][0];
    }

    //  Chamado pelo 'EventTrigger: On Value Changed' de cada Slider_X para alterar string com caminho do arquivo e redefinir imagem usada no cenário:
    public void UpdateSceneryImage(float sliderValue)
    {
        int sliderIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name.Split('_')[1]);

        switch (sliderIndex)
        {
            case 1:
                this.intensity = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
            case 2:
                this.color = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
            case 3:
                this.tfStatus = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
            case 4:
                this.uniformity = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
        }

        Debug.Log(this.GetImagePathString());
        this.RotationExceptionHandler(this.GetImagePathString());
        this.UpdateMaterialTexture(this.GetImagePathString());
    }

    //  Retorna a string com caminho do arquivo com os valores atuais definidos nos Sliders de 'Selection_Menu':
    public string GetImagePathString()
    {
        return this.intensity + "_" + this.color + "_" + this.tfStatus + "_" + this.uniformity;
    }

    //  Atualiza imagem usada no cenário de acordo com string com caminho do arquivo passado:
    private void UpdateMaterialTexture(string imagePath)
    {
        this.insideOutMaterial.mainTexture = Resources.Load<Texture>("Images/" + imagePath);
    }

    //  Corrige o erro de rotação presente em duas imagens passadas verificadas no condicional:
    private void RotationExceptionHandler(string imagePath)
    {
        if ((imagePath.Equals("10_3000K_OFF_LOW") || imagePath.Equals("10_6000K_OFF_LOW")))
        {
            if (!this.exceptionHandled)
            {
                this.exceptionHandled = !this.exceptionHandled;
                this.sphere.transform.Rotate(0, -2.22f, 0, Space.World);
            }
        }
        else
        {
            if (this.exceptionHandled)
            {
                this.exceptionHandled = !this.exceptionHandled;
                this.sphere.transform.rotation = this.defaultRotation;
            }
        }
    }
}
