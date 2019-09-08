using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private const float speed = 5f; // Character speed
    private const float mouseYMultiplicator = -20f; // Character rotation (Y axis, vertical)
    private const float mouseXMultiplicator = 40f; // Character rotation (X axis, horizontal)

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        // Debug: Release mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        // Move character
        Vector3 move = Vector3.zero;
        if (cc.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
        }
        move.y -= -Physics.gravity.y * Time.deltaTime;
        cc.Move(move * Time.deltaTime);
        // Rotate character
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * mouseYMultiplicator, Input.GetAxis("Mouse X") * mouseXMultiplicator, 0f) * Time.deltaTime);
    }
}
