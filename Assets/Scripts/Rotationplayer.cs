using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationWithCursor : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // Adjust the rotation speed as needed

    private void Update()
    {
        // Get the mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the rotation amount
        float rotationAmount = mouseX * rotationSpeed;

        // Apply rotation to the player's y-axis
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
