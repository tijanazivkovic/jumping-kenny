using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivityX = 1F;
    public float sensitivityY = 1F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    float rotationY = -60F;

    // For camera movement
    float CameraPanningSpeed = 10.0f;

    void Update()
    {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

   

}
