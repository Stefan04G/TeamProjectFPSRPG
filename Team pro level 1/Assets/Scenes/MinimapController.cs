using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector

    private void LateUpdate()
    {
        // Update the camera's position to follow the player
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Keep the camera's Y position fixed
        transform.position = newPosition;

        // Optional: Rotate the minimap to match the player's rotation
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}