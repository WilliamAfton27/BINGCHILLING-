using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject == player)
        {
            // Make the player disappear
            player.SetActive(false);
        }
    }
}
