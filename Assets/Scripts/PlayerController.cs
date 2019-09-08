using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private const float speed = 0.1f; // Character speed
    private const float mouseSensitivity = 40f; // Mouse sensitivity for camera rotation

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
    }

    public void FixedUpdate()
    {
        // Move character
        Vector3 move = Vector3.zero;
        if (cc.isGrounded)
        {
            move = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed;
        }
        move.y -= -Physics.gravity.y;
        cc.Move(move);

        // Rotate character
        // TODO: Need to check angle limits
        transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * mouseSensitivity, Input.GetAxis("Mouse X") * mouseSensitivity, 0.0f);
    }
}
