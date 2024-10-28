using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(Collider))]
    public class Despawner : MonoBehaviour
    {
        // This method is triggered when another collider enters the trigger zone
        void OnTriggerEnter(Collider other)
        {
            // Check if the object that entered the trigger zone is tagged as "Player"
            if (other.CompareTag("Player"))
            {
                // Reload the current scene (restart the level)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                // If not the player, destroy the object
                Destroy(other.gameObject);
            }
        }
    }
}
