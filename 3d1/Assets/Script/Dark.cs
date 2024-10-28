using UnityEngine;
using UnityEngine.UI; // For UI Image

public class CameraDarkenOnSpace : MonoBehaviour
{
    public Image overlayImage;           // Reference to the UI Image used to darken the screen
    public Color darkColor = new Color(0, 0, 0, 0.5f); // The darkened color (half transparent black)
    public Color normalColor = new Color(0, 0, 0, 0f); // The normal color (fully transparent)
    public KeyCode toggleKey = KeyCode.Space;          // The key to toggle darkening

    private bool isDarkened = false;     // Tracks whether the screen is currently darkened

    void Start()
    {
        // Make sure the overlay image is initially transparent
        if (overlayImage != null)
        {
            overlayImage.color = normalColor;
        }
        else
        {
            Debug.LogError("Overlay image is not assigned.");
        }
    }

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleDarken();
        }
    }

    void ToggleDarken()
    {
        if (overlayImage != null)
        {
            // Toggle between darkened and normal states
            if (isDarkened)
            {
                // Set the color back to normal (fully transparent)
                overlayImage.color = normalColor;
            }
            else
            {
                // Set the color to darkened (semi-transparent black)
                overlayImage.color = darkColor;
            }

            // Toggle the isDarkened flag
            isDarkened = !isDarkened;
        }
    }
}
