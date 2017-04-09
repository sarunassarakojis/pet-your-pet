using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetCameraPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime);
    }
}
