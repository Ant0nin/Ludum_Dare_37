using UnityEngine;

// TODO : add joypad support

public class PlayerGroundMoveListener : MonoBehaviour
{
    public float displacementSpeed = 3f;

    Rigidbody rigid;

    void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float joystickX = Input.GetAxis("Horizontal") * displacementSpeed;
        float joystickY = Input.GetAxis("Vertical") * displacementSpeed;
        rigid.velocity = transform.rotation * new Vector3(joystickX, 0, joystickY);
    }
}