using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float alertRadius = 5.0f; // Alert radius
    public AudioClip coinDropSound;  // Sound to play on drop

    private bool isDropped = false;  // To ensure coin drops only once
    private AudioSource audioSource; // AudioSource component reference

    

    private void Start()
    {

        // Find the AudioSource with the tag "SpecialAudioSource"
        GameObject audioSourceObject = GameObject.FindGameObjectWithTag("SFX");
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("AudioSource with tag 'SpecialAudioSource' not found.");
        }

        PlaySound();
        AlertSecurityGuards();
    }

   

   

    void PlaySound()
    {
        // Ensure the AudioClip is set before attempting to play the sound
        if (coinDropSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(coinDropSound);
        }
        else
        {
            Debug.LogWarning("Coin drop sound or AudioSource not set.");
        }
    }

    void AlertSecurityGuards()
    {
        // Get all colliders within the alert radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, alertRadius);
        foreach (var hitCollider in hitColliders)
        {
            // Try to get the RandomPatrolEnemy component
            RandomPatrolEnemy enemy = hitCollider.GetComponent<RandomPatrolEnemy>();
            if (enemy != null)
            {
                enemy.ReactToCoin(transform.position);
            }
        }
    }

    // Draw the alert radius in the editor for better visualization
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRadius);
    }
}