using Unity.VisualScripting;
using UnityEngine;

public class S_EnterWorkBench : MonoBehaviour, I_Interact
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject deskCamera;
    public void Interact(GameObject player)
    {
        enterCamera();
    }


    private void enterCamera()
    {
        S_PlayerInputActions.instance.inputs.Player.Disable();
        S_PlayerInputActions.instance.inputs.WorkBench.Enable();
        deskCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerCamera.SetActive(false);
    }

    private void exitCamera()
    {
        S_PlayerInputActions.instance.inputs.Player.Enable();
        S_PlayerInputActions.instance.inputs.WorkBench.Disable();
        deskCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera.SetActive(true);
    }

    private void Update()
    {
        if (S_PlayerInputActions.instance.inputs.WorkBench.Exit.WasPressedThisFrame()) exitCamera();
    }
}


