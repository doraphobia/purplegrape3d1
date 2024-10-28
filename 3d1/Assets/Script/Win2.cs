using UnityEngine;
using TMPro; // Make sure to include the TMPro namespace

public class CharacterDestinationTracker : MonoBehaviour
{
    public Transform[] movingCharacters;
    public Transform destinationPoint;   // The target location they need to reach
    public float acceptableDistance = 1.0f;  // Distance threshold for arrival
    public GameObject successCanvas;     // Canvas to display when all characters arrive
    public TMP_Text successText;         // TMP_Text for the success message

    private int reachedCount = 0;        // Tracks how many characters have reached the target
    private bool gameWon = false;        // Flag to indicate if all characters have arrived

    void Start()
    {
        if (successCanvas == null)
        {
            Debug.LogError("Success canvas is not assigned!");
        }

        if (successText == null)
        {
            Debug.LogError("Success text is not assigned!");
        }
        else
        {
            successText.gameObject.SetActive(false);  // Hide the text initially
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
        if (!gameWon)
        {
            CheckCharactersByDistance(); // Check the distance of each character to the target
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

        // Check if all characters have reached the target
        if (reachedCount == movingCharacters.Length && movingCharacters.Length > 0)
        {
            gameWon = true;
            DisplaySuccessMessage();
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
            gameWon = true;
            DisplaySuccessMessage();
        }
    }

    // Display the success message
    void DisplaySuccessMessage()
    {
        if (successText != null)
        {
            successText.gameObject.SetActive(true);  // Show the success text
        }
        else
        {
            Debug.LogError("Success text is not assigned!");
        }
    }
}
