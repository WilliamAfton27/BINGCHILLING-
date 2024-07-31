using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{

    public Button exitButton;

    void Start()
    {
        // Ensure the button component is assigned
        if (exitButton == null)
        {
            exitButton = GetComponent<Button>();
        }

        // Add a listener to the button to call the ExitGame method when clicked
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // Code to exit the game
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}