using UnityEngine;
using UnityEngine.InputSystem;
public class playerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    // Called automatically when Move action is triggered
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}