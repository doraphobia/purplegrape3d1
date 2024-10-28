using UnityEngine;
using UnityEngine.SceneManagement; // To allow for scene reloading

public class PlayerDeathOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string enemyTag = "Enemy"; // Tag of the objects that will trigger the player's death

    // This method is called when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the correct tag (for example, "Enemy")
        if (other.CompareTag(enemyTag))
        {
            // Call the Die method to restart the scene
            Die();
        }
    }

    // Method to handle the player's "death"
    void Die()
    {
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
