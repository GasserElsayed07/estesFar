using UnityEngine;

public class FloatingPickup : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatAmplitude = 0.25f;   // height of floating
    public float floatFrequency = 2f;      // speed of floating

    [Header("Rotation Settings")]
    public float rotationSpeed = 90f;      // degrees per second (Y axis)

    [Header("Fake Depth Settings")]
    public bool enablePulse = true;
    public float pulseAmplitude = 0.05f;   // how much it scales
    public float pulseFrequency = 3f;      // speed of pulsing

    private Vector3 startPos;
    private Vector3 baseScale;

    void Start()
    {
        startPos = transform.position;
        baseScale = transform.localScale;
    }

    void Update()
    {
        // 1. Floating motion
        float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);

        // 2. Rotation (coin spin style)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // 3. Fake depth pulse
        if (enablePulse)
        {
            float scaleOffset = 1f + Mathf.Sin(Time.time * pulseFrequency) * pulseAmplitude;
            transform.localScale = baseScale * scaleOffset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered");
        if (other.CompareTag("Player"))
        {
            // Access the player's script and "add" this item
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(gameObject.name); // pass item name or ID
            }
            Debug.Log("Item picked up");
            // destroy the pickup object
            Destroy(gameObject);
        }
    }
}
