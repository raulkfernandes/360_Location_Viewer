using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneryImageHandler : MonoBehaviour
{
    [SerializeField] private Material insideOutMaterial;
    [SerializeField] private GameObject sphere;
    private Quaternion defaultRotation;
    private bool exceptionHandled = false;

    private Dictionary<int, string[]> imageHandler = new Dictionary<int, string[]>();
    private string intensity, color, tfa, uniformity;

    private void Awake()
    {
        this.InitializeImageHandler();
        this.defaultRotation = this.sphere.transform.rotation;
    }

    private void OnApplicationQuit()
    {
        this.insideOutMaterial.mainTexture = Resources.Load<Texture>("Images/" + this.GetInitialPathString());
    }

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
                this.tfa = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
            case 4:
                this.uniformity = this.imageHandler[sliderIndex][(int)sliderValue - 1];
                break;
        }

        //Debug.Log(this.GetImagePathString());
        this.RotationExceptionHandler(this.GetImagePathString());
        this.insideOutMaterial.mainTexture = Resources.Load<Texture>("Images/" + this.GetImagePathString());
    }

    public string GetImagePathString()
    {
        return this.intensity + "_" + this.color + "_" + this.tfa + "_" + this.uniformity;
    }

    private string GetInitialPathString()
    {
        return this.imageHandler[1][0] + "_" + this.imageHandler[2][0] + "_" + this.imageHandler[3][0] + "_" + this.imageHandler[4][0];
    }

    private void InitializeImageHandler()
    {
        this.imageHandler.Add(1, new string[] { "2.5", "10", "20", "50" });
        this.imageHandler.Add(2, new string[] { "3000K", "6000K" });
        this.imageHandler.Add(3, new string[] { "OFF", "ON" });
        this.imageHandler.Add(4, new string[] { "LOW", "HIGH" });

        this.SetInitialValues();
    }

    private void SetInitialValues()
    {
        this.intensity = this.imageHandler[1][0];
        this.color = this.imageHandler[2][0];
        this.tfa = this.imageHandler[3][0];
        this.uniformity = this.imageHandler[4][0];
    }

    private void RotationExceptionHandler(string pathString)
    {
        if ((pathString.Equals("10_3000K_OFF_LOW") || pathString.Equals("10_6000K_OFF_LOW")))
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
