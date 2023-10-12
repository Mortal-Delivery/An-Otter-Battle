using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 2f;
    public float maxZoom = 8f;
    public float pitch = 2f; // Offset of where to look from character's feet.

    public float yawSpeed = 100f;

    private float currentZoom = 5f;
    private float currentYaw = 0f;

    // Update is called once per frame
    void Update()
    {
        // Zooming
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Camera rotation
        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate ()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        // Camera Rotating
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
