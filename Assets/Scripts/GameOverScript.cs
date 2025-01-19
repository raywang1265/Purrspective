using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) // Detect any key press
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reload the active scene (current game scene)
        SceneManager.LoadScene("level");
    }
}
