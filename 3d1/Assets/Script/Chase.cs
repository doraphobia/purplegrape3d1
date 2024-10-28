using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed at which the object moves

    void Start()
    {
        // Automatically find the player object by tag (assuming your player is tagged as "Player")
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("No player found with the 'Player' tag.");
            }
        }
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
