using UnityEngine;

public class MoveCameraWithArrows : MonoBehaviour
{
    public float moveSpeed = 10.0f;   // Speed of camera movement

    void Update()
    {
        // Get the horizontal and vertical input from the arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");  // Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical");      // Up/Down arrow keys

        // Calculate the movement direction (X and Z axes)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the camera's position
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
