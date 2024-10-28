using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the enemy
    public Transform leftLimit; // The left limit for movement
    public Transform rightLimit; // The right limit for movement

    private Vector3 moveDirection; // Current move direction

    void Start()
    {
        // Initialize the move direction to right
        moveDirection = Vector3.right;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Move the enemy
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Check if the enemy has reached the limits
        if (transform.position.x >= rightLimit.position.x)
        {
            moveDirection = Vector3.left; // Change direction to left
            Debug.Log("Changing direction to left"); // Debug log
        }
        else if (transform.position.x <= leftLimit.position.x)
        {
            moveDirection = Vector3.right; // Change direction to right
            Debug.Log("Changing direction to right"); // Debug log
        }

        // Debugging logs to track position
        Debug.Log($"Current Position: {transform.position.x}, Left Limit: {leftLimit.position.x}, Right Limit: {rightLimit.position.x}");
    }

    // Method to destroy the enemy
    public void DestroyEnemy()
    {
        Destroy(gameObject); // Destroy the enemy GameObject
    }

    // Collision detection with bullets
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Check if collided with a bullet
        {
            DestroyEnemy(); // Call the method to destroy the enemy
            Destroy(other.gameObject); // Destroy the bullet
        }
    }
}
