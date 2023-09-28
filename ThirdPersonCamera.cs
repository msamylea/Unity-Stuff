using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float panSpeed = 5.0f;
    public float zoomSpeed = 10.0f;
    public float minZoom = 2.0f;
    public float maxZoom = 10.0f;
    public float smoothSpeed = 0.125f;

    private float currentZoom;
    private Quaternion currentOrientation;

    void Start()
    {
        currentZoom = distance;
        currentOrientation = Quaternion.Euler(0, target.eulerAngles.y, 0);
    }

    void Update()
    {
        // Panning and tilting with right mouse button
        if (Input.GetMouseButton(1))
        {
            float horizontal = Input.GetAxis("Mouse X") * panSpeed;
            float vertical = Input.GetAxis("Mouse Y") * panSpeed;

            currentOrientation *= Quaternion.Euler(-vertical, horizontal, 0);

            float tilt = currentOrientation.eulerAngles.x;
            // Clamp tilt angle
            tilt = tilt > 180 ? tilt - 360 : tilt;
            tilt = Mathf.Clamp(tilt, -30, 30);

            currentOrientation = Quaternion.Euler(tilt, currentOrientation.eulerAngles.y, 0);
        }

        // Zooming with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom - scroll, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        // Calculate the position based on the orientation and distance
        Vector3 offset = new Vector3(0, height, -currentZoom);
        Vector3 newPosition = target.position + currentOrientation * offset;

        // Smoothly transition to the new position
        transform.position = newPosition;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
