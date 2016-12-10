using UnityEngine;

public class PlayerViewListener : MonoBehaviour
{
    public float lookSensibility = 4f;

    Transform view;

    void Start() {
        view = transform.GetChild(0);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensibility;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensibility;

        Vector3 localVerticalAxis = transform.worldToLocalMatrix.MultiplyVector(transform.up);
        Vector3 localHorizontalAxis = transform.worldToLocalMatrix.MultiplyVector(-transform.right);

        transform.Rotate(localVerticalAxis, mouseX);
        view.Rotate(localHorizontalAxis, mouseY);
    }
}