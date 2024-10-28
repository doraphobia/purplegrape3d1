using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Speed of the bullet
    public float lifetime = 2f; // Lifetime before the bullet is destroyed

    // Static kill count variable to track the number of killed enemies
    public static int killCount = 0;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // Set the bullet's velocity
        }

        // Destroy the bullet after its lifetime
        Destroy(gameObject, lifetime);
    }

    // This method is called when the bullet's trigger collider touches another collider
    void OnTriggerEnter(Collider other)
    {
        // Log the object that the bullet collided with
        Debug.Log("Bullet collided with: " + other.gameObject.name);

        // Check if the bullet hit an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Increase the kill count
            killCount++;

            // Log the kill count (optional for debugging purposes)
            Debug.Log("Enemy hit! Kill count: " + killCount);

            // Destroy the enemy
            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
        else
        {
            // Log if the bullet hit something that isn't tagged as "Enemy"
            Debug.Log("Bullet hit a non-enemy object: " + other.gameObject.name);
        }
    }
}
