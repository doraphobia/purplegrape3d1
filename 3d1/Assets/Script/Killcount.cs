using UnityEngine;
using UnityEngine.UI;

public class KillCountDisplay : MonoBehaviour
{
    public Text killCountText; // Reference to the UI Text element

    void Update()
    {
        // Update the UI text with the current kill count
        killCountText.text = "Enemies Killed: " + Bullet.killCount;
    }
}
