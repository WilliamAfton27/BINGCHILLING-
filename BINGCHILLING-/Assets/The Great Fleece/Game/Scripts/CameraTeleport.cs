using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    // Define the position to which the camera will teleport
    public Vector3 teleportPosition = new Vector3(0, 10, -10);

    // This method is called when the game starts
    void Start()
    {
        // Set the camera's position to the teleport position
        transform.position = teleportPosition;
    }
}
