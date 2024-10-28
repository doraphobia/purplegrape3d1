using UnityEngine;
using UnityEngine.SceneManagement; // For scene management (loading the next level)

public class CharacterNextLevelTracker : MonoBehaviour
{
    public Transform[] movingCharacters;  // Characters that need to reach the destination
    public Transform destinationPoint;    // Target location they need to reach
    public float acceptableDistance = 1.0f;  // Distance threshold for arrival
    public string nextLevelName;          // The name of the next scene/level to load

    private int reachedCount = 0;         // Tracks how many characters have reached the target
    private bool levelComplete = false;   // Flag to indicate if all characters have arrived

    void Start()
    {
        if (string.IsNullOrEmpty(nextLevelName))
        {
            Debug.LogError("Next level name is not assigned!");
        }

        if (movingCharacters == null || movingCharacters.Length == 0)
        {
            Debug.LogError("Moving characters array is not assigned or empty!");
        }
        else
        {
            foreach (Transform character in movingCharacters)
            {
                if (character == null)
                {
                    Debug.LogError("A character's transform is missing.");
                }
            }
        }
    }

    void Update()
    {
        if (!levelComplete)
        {
            CheckCharactersByDistance(); // Check if all characters have reached the target
        }
    }

    void CheckCharactersByDistance()
    {
        reachedCount = 0;

        foreach (Transform character in movingCharacters)
        {
            if (character != null)
            {
                if (Vector3.Distance(character.position, destinationPoint.position) <= acceptableDistance)
                {
                    reachedCount++;
                }
            }
        }

        // If all characters have reached the target, load the next level
        if (reachedCount == movingCharacters.Length && movingCharacters.Length > 0)
        {
            levelComplete = true;
            LoadNextLevel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (Transform character in movingCharacters)
        {
            if (other.transform == character)
            {
                reachedCount++;
                CheckWinCondition();
                break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (Transform character in movingCharacters)
        {
            if (collision.transform == character)
            {
                reachedCount++;
                CheckWinCondition();
                break;
            }
        }
    }

    void CheckWinCondition()
    {
        if (reachedCount == movingCharacters.Length && movingCharacters.Length > 0)
        {
            levelComplete = true;
            LoadNextLevel();
        }
    }

    // Load the next level
    void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            // Load the next scene/level by name
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogError("Next level name is not set!");
        }
    }
}
