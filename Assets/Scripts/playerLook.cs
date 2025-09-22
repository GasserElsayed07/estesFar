using UnityEngine;
using UnityEngine.InputSystem;
public class playerLook : MonoBehaviour
{

    public float sensitivity = 2f;
    public Transform playerCamera;
    private Vector2 lookInput;
    private float Xrotation = 0f;

    void OnLook(InputValue manga)
    {
        lookInput = manga.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = lookInput.x * sensitivity * Time.deltaTime;
        float mouseY = lookInput.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
    }
}
