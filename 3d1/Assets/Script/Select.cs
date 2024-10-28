using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class LevelLoader : MonoBehaviour
{
    // This method is called when a button is clicked and the corresponding level is loaded
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // Load the scene by its name
    }
}
