using UnityEngine;

public class S_PlayerInputActions : MonoBehaviour
{
    // INPUT ACTIONS SIGLEtON
    public static S_PlayerInputActions instance;
    public InputSystem_Actions inputs;

    private void Awake()
    {
        if (instance != null && instance != this) // destroy if we already have one
        {
            Destroy(gameObject);
            return;
        }

        instance = this; // instance and dont destroy just in case
        DontDestroyOnLoad(gameObject);

        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Player.Enable(); 
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }

    // If we want to enable or disable it (mostly for the workbench and UI)
    public void EnablePlayerControls()
    {
        inputs.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DisablePlayerControls()
    {
        inputs.Player.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
