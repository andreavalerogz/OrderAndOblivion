using UnityEngine;

public class S_PlayerInteract : MonoBehaviour
{
    LayerMask pickUpMask; // pickup layer
    [SerializeField] private float maxDistance = 20f;

    void Awake()
    {
        pickUpMask = LayerMask.GetMask("PickUps");
    }


    void Update()
    {
        if (S_PlayerInputActions.instance.inputs.Player.Interact.WasPressedThisFrame()) // player presses E
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpMask))
            {
                Debug.Log("Did Hit");
                I_Interact target = hit.collider.gameObject.GetComponent<I_Interact>();
                if(target != null) target.Interact(gameObject);
            }
        }
    }
}
