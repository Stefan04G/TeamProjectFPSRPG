using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform player; // Reference to the player

    private void LateUpdate()
    {
        // Update the mini-map camera's position to follow the player
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Keep the camera's Y position
        transform.position = newPosition;

        // Optional: Rotate the mini-map to match the player's rotation
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}