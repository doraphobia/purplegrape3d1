using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the target's position
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the target

    void LateUpdate()
    {
        // Desired position based on the target's position and the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Optionally, make the camera look at the target
        transform.LookAt(target);
    }
}
