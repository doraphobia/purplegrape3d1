using UnityEngine;

public class WASD : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component
    public float speed = 12f;              // Player movement speed
    public float gravity = -9.81f;         // Gravity value
    public float jumpHeight = 3f;          // How high the player can jump

    Vector3 velocity;                      // Current velocity for gravity calculation
    bool isGrounded;                       // Check if the player is grounded
    bool hasJumped;                        // Check if the player has already jumped

    public Transform groundCheck;          // Position used to check if the player is on the ground
    public float groundDistance = 0.4f;    // Distance from the groundCheck to the ground
    public LayerMask groundMask;           // Layer that defines what is considered "ground"

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If grounded and the player has finished a jump, reset jump ability
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the player sticks to the ground
            hasJumped = false; // Reset jumping state once the player lands
        }

        // Get input from the WASD keys or arrow keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the player's current facing direction
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player using the CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Jump if the player presses the Space bar, is grounded, and hasn't jumped yet
        if (Input.GetButtonDown("Jump") && isGrounded && !hasJumped)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            hasJumped = true; // Set the flag so the player can't jump again in mid-air
        }

        // Apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;

        // Apply the gravity to the player
        controller.Move(velocity * Time.deltaTime);
    }
}
