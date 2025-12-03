using UnityEngine;

public class ReadingBookFollow : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Vector3 localOffset = new Vector3(0f, -0.3f, 0.7f);

    void LateUpdate()
    {
        if (playerCamera == null) return;

        // Place book in front of camera
        transform.position = playerCamera.TransformPoint(localOffset);

        // Make book face the camera
        transform.rotation = Quaternion.LookRotation(
            transform.position - playerCamera.position
        );
    }
}
