using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset;
    public Vector3 rotation;

    private void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y;
        transform.position = desiredPosition;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
