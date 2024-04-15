using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{
    public float cameraSpeed = 5.0f; // Adjust the camera movement speed as needed.

    void Update()
    {
        // Get the current cursor position in screen coordinates.
        Vector3 cursorScreenPos = Input.mousePosition;

        // Convert the screen position to a world point in the plane of your choice (e.g., the ground).
        // Ensure the plane is at the same height as your camera's Y position.
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));
        Ray ray = Camera.main.ScreenPointToRay(cursorScreenPos);

        if (groundPlane.Raycast(ray, out float hitDistance))
        {
            Vector3 cursorWorldPos = ray.GetPoint(hitDistance);

            // Smoothly move the camera toward the cursor position.
            Vector3 newPosition = Vector3.Lerp(transform.position, cursorWorldPos, Time.deltaTime * cameraSpeed);
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }
    }
}
