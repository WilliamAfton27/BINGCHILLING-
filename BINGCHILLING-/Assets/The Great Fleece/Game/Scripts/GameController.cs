using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void RestartGame()
    {
        // Load the currently active scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}