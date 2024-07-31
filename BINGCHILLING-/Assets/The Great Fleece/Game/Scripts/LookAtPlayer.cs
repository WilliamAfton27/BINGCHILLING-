using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target; // Reference to the player's transform

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the camera to the player
            Vector3 direction = target.position - transform.position;

            // Calculate the rotation to look at the player
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Apply the rotation to the camera
            transform.rotation = rotation;
        }
    }
}