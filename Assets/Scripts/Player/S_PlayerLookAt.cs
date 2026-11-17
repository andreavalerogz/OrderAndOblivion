using UnityEngine;
using UnityEngine.Windows;

public class S_PlayerLookAt : MonoBehaviour
{
    InputSystem_Actions inputs;
    float pitch;
    public float sensitivity = 0.1f;
    public float maxPitch = 80f;
    public Transform cameraTransform;

    private void OnEnable()
    {
        inputs.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void Update()
    {
        Vector2 look = inputs.Player.Look.ReadValue<Vector2>() * sensitivity;

        transform.Rotate(Vector3.up * look.x);              
        pitch = Mathf.Clamp(pitch - look.y, -maxPitch, maxPitch);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

}
