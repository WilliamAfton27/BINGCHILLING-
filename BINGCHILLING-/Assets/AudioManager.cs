using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Static instance of AudioManager which allows it to be accessed by any other script
    public static AudioManager instance = null;

    // Awake is always called before any Start functions
    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this
        else if (instance != this)
        {
            // Then destroy this. This enforces the singleton pattern, meaning there can only ever be one instance of an AudioManager
            Destroy(gameObject);
        }

        // Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading a scene
        DontDestroyOnLoad(gameObject);
    }

    // Add your AudioManager methods and variables here
    public void PlaySound(AudioClip clip)
    {
        // Implementation for playing a sound
    }

    public void StopSound()
    {
        // Implementation for stopping a sound
    }
}
