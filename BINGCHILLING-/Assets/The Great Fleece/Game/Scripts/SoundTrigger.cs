using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource[] specialSoundsToTurnOn; // Array to hold references to the special sounds to turn on

    // This function is called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is the one who entered the trigger
        if (other.CompareTag("Player"))
        {
            // Turn off all sounds in the game
            AudioSource[] allSounds = FindObjectsOfType<AudioSource>();
            foreach (AudioSource sound in allSounds)
            {
                if (sound.isPlaying)
                {
                    sound.Stop();
                }
            }

            // Turn on all special sounds
            foreach (AudioSource specialSound in specialSoundsToTurnOn)
            {
                if (!specialSound.isPlaying)
                {
                    specialSound.Play();
                }
            }
        }
    }
}