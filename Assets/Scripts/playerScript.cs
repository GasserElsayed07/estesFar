using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Vector2 moveInput;
    private Rigidbody rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump() // hook this up in Input Actions
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 moveVelocity = move * moveSpeed;
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
