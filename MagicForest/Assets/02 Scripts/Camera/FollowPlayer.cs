using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform[] playerTransform;
    [SerializeField] private Vector3 offset;

    private float cameraRotationSpeed = 5.0f;
    private float cameraXRotation = 0f;
    private float cameraYRotation = 0f;
    private void LateUpdate()
    {
        if (PlayerData.selectNum == 1)
        {
            transform.position = playerTransform[0].position + offset;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.eulerAngles.z);
        }
        else if (PlayerData.selectNum == 2)
        {
            transform.position = playerTransform[1].position + offset;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.eulerAngles.z);
        }

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        float mouseX = Input.GetAxis("Mouse X") * cameraRotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * cameraRotationSpeed;

        cameraYRotation += mouseX;
        cameraXRotation -= mouseY;
        cameraYRotation = Mathf.Clamp(cameraYRotation, -120f, 120f);
        cameraXRotation = Mathf.Clamp(cameraXRotation, -60f, 60f);
        transform.rotation = Quaternion.Euler(cameraXRotation, cameraYRotation, 0.0f);

#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                cameraYRotation += touch.deltaPosition.x * cameraRotationSpeed;
                cameraXRotation -= touch.deltaPosition.y * cameraRotationSpeed;
                cameraYRotation = Mathf.Clamp(cameraYRotation, 60f,240f);
                cameraXRotation = Mathf.Clamp(cameraXRotation, -60f, 60f);

                transform.rotation = Quaternion.Euler(cameraXRotation, cameraYRotation, 0.0f);
            }
        }
#endif
    }
}
