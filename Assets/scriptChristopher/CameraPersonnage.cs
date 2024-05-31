using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
    public Transform target;  // The target the camera will follow
    public float smoothSpeed = 0.125f;  // The speed of the camera follow
    public Vector3 offset;  // The offset from the target position

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned in CameraFollow script.");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
