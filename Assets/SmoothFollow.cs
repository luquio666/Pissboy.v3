using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;  // The object to follow
    public float smoothSpeed = 0.125f;  // The smoothness of camera movement
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        Vector3 fixedPosition = new Vector3(smoothedPosition.x, 0, smoothedPosition.z);
        transform.position = fixedPosition;

        //transform.LookAt(target);
    }
}
