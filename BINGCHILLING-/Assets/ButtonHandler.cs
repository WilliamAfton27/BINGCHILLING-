using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button myButton; // Assign in the Inspector
    public AudioClip buttonSound; // Assign in the Inspector
    public string sceneToLoad; // Assign the scene name in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        audioSource.PlayOneShot(buttonSound);
        StartCoroutine(TeleportAfterSound());
    }

    private IEnumerator TeleportAfterSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
        SceneManager.LoadScene(sceneToLoad);
    }
}
