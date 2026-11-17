using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    InputSystem_Actions inputs;
    public float speed = 3f;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = inputs.Player.Move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        dir = transform.TransformDirection(dir); // local -> movimiento del mundo

        transform.position += dir * speed * Time.deltaTime;

    }
}
