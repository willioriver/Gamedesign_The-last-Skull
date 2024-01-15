using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public float runMultiplier = 1.5f;

    private void Update()
    {
        // Input for movement
         float horizontalInput = Input.GetAxis("Horizontal");
       

        // Input for rotation
        float verticalInput = Input.GetAxis("Vertical");

        // Input for run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calculate movement and rotation
        Vector3 movement = transform.forward * verticalInput * moveSpeed * (isRunning ? runMultiplier : 1f) * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 rotation = new Vector3(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);

        // You can also use Rigidbody for more complex physics interactions.
        Rigidbody rb = GetComponent<Rigidbody>();
         rb.MovePosition(transform.position + movement);
      rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
}
