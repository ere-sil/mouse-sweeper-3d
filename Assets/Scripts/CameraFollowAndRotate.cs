using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraFollowAndRotate : MonoBehaviour
{
    //vanhat pätkät perus-seuraavaa kameraa varten
    //public GameObject player;
    //public Transform target;
    //public Vector3 offset;
    //public float sensitivity = 1;
    //public float smoothSpeed = 0.1f;
    private float cameraMoveSpeed = 120;
    public GameObject cameraFollow;
    Vector3 FollowPOS;
    private float clampAngleMax = 60.0f;
    private float clampAngleMin = -75.0f;
    private float inputSensitivityX = 120.0f;
    private float inputSensitivityY = 120.0f;
    public GameObject player;
    public GameObject camera;
    public float camDistanceToPlayerX;
    public float camDistanceToPlayerY;
    public float camDistanceToPlayerZ;
    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    private Quaternion camRotation;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseY = Input.GetAxis("Mouse Y");
        //rotX += -mouseY * inputSensitivityY * Time.deltaTime;
        //rotX = Mathf.Clamp(rotX, clampAngleMin, clampAngleMax);
        //Quaternion localRotation = Quaternion.Euler(rotX, 0, 0.0f);
        //transform.rotation = localRotation;

        //mouseX = Input.GetAxis("Mouse X");
        //rotY = mouseX * inputSensitivityX * Time.deltaTime;
        //player.transform.Rotate(0, rotY, 0); //new
        //float desiredAngleY = player.transform.eulerAngles.y;
        //camRotation = Quaternion.Euler(0, desiredAngleY, 0);
        //transform.position = player.transform.position - (camRotation * offset);
        //transform.LookAt(player.transform);
        mouseY = Input.GetAxis("Mouse Y");
        rotX += -mouseY * inputSensitivityY * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, clampAngleMin, clampAngleMax);
        Quaternion localRotation = Quaternion.Euler(rotX,0, 0.0f);
        transform.rotation = localRotation;

        //mouseX = Input.GetAxis("Mouse X");
        //rotY = mouseX * inputSensitivityX * Time.deltaTime;
        //player.transform.Rotate(0, rotY, 0); //new
        //float desiredAngleY = player.transform.eulerAngles.y;
        //camRotation = Quaternion.Euler(0, desiredAngleY, 0);
        //transform.LookAt(player.transform);
    }

    void LateUpdate()
    {
        CameraUpdater();
        //Vanhoja pätkiä
        //if (GameObject.FindGameObjectWithTag("Player"))
        //{
        //    Vector3 desiredPosition = target.position + offset;
        //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    transform.position = smoothedPosition;
        //}
    }


    void CameraUpdater()
    {
        Transform target = cameraFollow.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


    }
    //this method rotates camera around the point where it's offset is and ignores player
    void simpleRotationMethod() 
    {
        //        float rotateHorizontal = Input.GetAxis("Mouse X");
        //        float rotateVertical = Input.GetAxis("Mouse Y");
        //       transform.RotateAround(player.transform.position, Vector3.up, rotateHorizontal * sensitivity);
        //       transform.RotateAround(Vector3.zero, transform.right,  rotateVertical * sensitivity);
    }
}