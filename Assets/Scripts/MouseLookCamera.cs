using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeedX = 5;
    public float rotateSpeedY = 2;
    public Vector3 offset;
    public float minAngle = -30;
    public float maxAngle = 45;
    private Quaternion camRotation;
 //   private float verticalLook = 30;

    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        rotateCameraY();
    }

    void rotateCameraY()
    {
        float horizontalLook = Input.GetAxis("Mouse X") * rotateSpeedX;
        target.transform.Rotate(0, horizontalLook, 0);
        float desiredAngleY = target.transform.eulerAngles.y;
        camRotation = Quaternion.Euler(0, desiredAngleY, 0);
        transform.position = target.transform.position - (camRotation * offset);
        transform.LookAt(target.transform);
    }

    // not working scripts to rotate camera around player
    //void rotateCameraX()
    //{
    //    camRotation.x = Input.GetAxis("Mouse Y") * rotateSpeedY;
    //    target.transform.Rotate(0, camRotation.x, 0);
    //    //transform.localRotation = Quaternion.Euler(-camRotation.x, 0, 0);
    //    camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);
    //    transform.position = target.transform.position - (camRotation.x * offset);
    //    transform.LookAt(target.transform);

    //}
    //void rotateCamera()
    //{
    //    camRotation.y = Input.GetAxis("Mouse X") * rotateSpeedX;
    //    camRotation.x = Input.GetAxis("Mouse Y") * rotateSpeedY;
    //    target.transform.Rotate(camRotation.x, camRotation.y, 0);
    //    //transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, 0);
    //    camRotation.y = target.transform.eulerAngles.y;
    //    camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);
    //    camRotation = Quaternion.Euler(camRotation.x, camRotation.y, 0);
    //    transform.position = target.transform.position - (Quaternion.Euler(camRotation.x, camRotation.y, 0)
    //        * offset);
    //    transform.LookAt(target.transform);
    //}
}