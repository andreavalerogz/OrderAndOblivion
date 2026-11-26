using UnityEngine;

public class S_PlayerInteract : MonoBehaviour
{
    LayerMask interactuableMask; // pickup layer
    [SerializeField] private float maxDistance = 20f;

    void Awake()
    {
        interactuableMask = LayerMask.GetMask("Interactuable");
    }


    void Update()
    {
        if (S_PlayerInputActions.instance.inputs.Player.Interact.WasPressedThisFrame()) // player presses E
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, interactuableMask))
            {
                Debug.Log("Did Hit");
                I_Interact target = hit.collider.gameObject.GetComponent<I_Interact>();
                if(target != null) target.Interact(gameObject);
            }


        }
    }
}
