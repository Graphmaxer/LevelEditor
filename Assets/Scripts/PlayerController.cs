using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private const float speed = 5f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Update()
    {
        Vector3 move = Vector3.zero;
        if (cc.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
        }
        move.y -= -Physics.gravity.y * Time.deltaTime;
        cc.Move(move * Time.deltaTime);
    }
}
