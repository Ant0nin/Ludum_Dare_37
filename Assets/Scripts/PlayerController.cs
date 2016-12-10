using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float displacementSpeed = 4f;
    public float lookSensibility = 2f;

    Rigidbody rigid;
    Transform view;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        view = transform.GetChild(0);
    }
	
	void Update ()
    {
        UpdateDisplacement();
        UpdateView();
    }

    void UpdateDisplacement()
    {
        float joystickX = Input.GetAxis("Horizontal") * displacementSpeed;
        float joystickY = Input.GetAxis("Vertical") * displacementSpeed;
        rigid.velocity = transform.rotation * new Vector3(joystickX, 0, joystickY);
    }

    // TODO : add joypad support
    void UpdateView()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensibility;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensibility;

        Vector3 localVerticalAxis = transform.worldToLocalMatrix.MultiplyVector(transform.up);
        Vector3 localHorizontalAxis = transform.worldToLocalMatrix.MultiplyVector(-transform.right);

        transform.Rotate(localVerticalAxis, mouseX);
        view.Rotate(localHorizontalAxis, mouseY);
    }
}
