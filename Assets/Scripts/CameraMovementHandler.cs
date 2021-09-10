using UnityEngine;

public class CameraMovementHandler : MonoBehaviour
{
    [SerializeField] [Range(0, 10f)] private float mouseSensitivity;
    [SerializeField] [Range(0, 90f)] private float viewLimitAngle;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes = RotationAxes.MouseXAndY;
    private float rotationY = 0f;

    //  Altera rotação da camera de acordo com posição do mouse no cenário:
    private void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, -viewLimitAngle, viewLimitAngle);

            this.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            this.transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, -viewLimitAngle, viewLimitAngle);

            this.transform.localEulerAngles = new Vector3(-rotationY, this.transform.localEulerAngles.y, 0);
        }
    }
}
