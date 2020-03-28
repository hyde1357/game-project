using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCam, centerPoint;
    public float distance, orbitingSpeed, verticalSpeed, maxHeight, minHeight;
    float height;

    void Update ()
    {
        centerPoint.position = gameObject.transform.position + new Vector3(0, 0, 0);
        centerPoint.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * orbitingSpeed, 0);
        height += Input.GetAxis("Mouse Y") * Time.deltaTime * -verticalSpeed;
        height = Mathf.Clamp(height, minHeight, maxHeight);
    }

    private void LateUpdate()
    {
        playerCam.position = centerPoint.position + centerPoint.forward * -1 * distance + Vector3.up * height;
        playerCam.LookAt(centerPoint);
    }
}
