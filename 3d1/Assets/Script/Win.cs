using UnityEngine;
using UnityEngine.UI;

public class CharacterArrivalTracker : MonoBehaviour
{
    public Transform[] characters;
    public Transform target;        // The spot they need to arrive at
    public float arrivalDistance = 1.0f;  // Distance check (in case needed)
    public Text progressText;       // UI Text to show progress
    public GameObject winCanvas;    // Canvas to show when all characters have arrived

    private int arrivedCount = 0;   // Tracks how many characters have arrived
    private bool isWin = false;     // Flag to check if game is won

    void Start()
    {
        if (winCanvas == null)
        {
            Debug.LogError("Win canvas is not assigned!");
        }
        else
        {
            winCanvas.SetActive(false);  // Hide win canvas initially
        }

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("Characters array is not assigned or empty!");
        }
        else
        {
            foreach (Transform character in characters)
            {
                if (character == null)
                {
                    Debug.LogError("A character transform is missing.");
                }
            }
        }

        UpdateProgressUI(); // Update the initial progress UI
    }

    void Update()
    {
        if (!isWin)
        {
            CheckCharacterArrivalByDistance(); // Optional distance-based check
        }
    }

    void CheckCharacterArrivalByDistance()
    {
        arrivedCount = 0;

        foreach (Transform character in characters)
        {
            if (character != null)
            {
                if (Vector3.Distance(character.position, target.position) <= arrivalDistance)
                {
                    arrivedCount++;
                }
            }
        }

        UpdateProgressUI();

        // Check if all characters have arrived
        if (arrivedCount == characters.Length && characters.Length > 0)
        {
            isWin = true;
            ShowWinMessage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (Transform character in characters)
        {
            if (other.transform == character)
            {
                arrivedCount++;
                UpdateProgressUI();
                CheckWinCondition();
                break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (Transform character in characters)
        {
            if (collision.transform == character)
            {
                arrivedCount++;
                UpdateProgressUI();
                CheckWinCondition();
                break;
            }
        }
    }

    void CheckWinCondition()
    {
        if (arrivedCount == characters.Length && characters.Length > 0)
        {
            isWin = true;
            ShowWinMessage();
        }
    }

    void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = "Arrived: " + arrivedCount + " / " + characters.Length;
        }
        else
        {
            Debug.LogError("Progress text is not assigned!");
        }
    }

    // Display the win message
    void ShowWinMessage()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("Win canvas is not assigned!");
        }
    }
}
