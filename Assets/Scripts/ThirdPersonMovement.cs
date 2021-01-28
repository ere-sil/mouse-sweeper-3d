using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private Rigidbody playerRb;

    public float movingSpeed;
    public float runningSpeedModifier;
    public float jumpForce;
    public float jumpForceModifier;
    Vector3 movement;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private bool isGrounded;
    private bool isRunning = false;
    private bool canMove = true;

    public float gravityModifier;

    float timeLeft = 1;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics.gravity *= gravityModifier;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        movePlayer();
        jumpPlayer();
        timeLeft = issGrounded();
        if (GameController.gamePlaying == false)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    float issGrounded()
    {
        if (isGrounded)
        {
            timeLeft = Timer.timerFunc(timeLeft);
            if (timeLeft <= 0)
            {
                Debug.Log("Grounded");
                timeLeft = 1;
            }
        }
        return timeLeft;
    }

    //takes horizontal and vertical axises from mouse and uses them to turn the camera and move player to the camera direction
    private void movePlayer()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //checks if player is running
        isRunning = Input.GetKey(KeyCode.LeftShift);
        Vector3 direction = new Vector3(horizontalInput, 0.0f, forwardInput).normalized;

        if (direction.magnitude >= 0.1F && canMove == true)
        {
            //uses Atan and radi2deg functions to adjust angle, where player should be moving
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //uses smoothdampangle function to smoothen the angle rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            
            //finally rotates player
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //moves player to target angles direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //sets player running when shift is pressed
            setPlayerRunning(isRunning);
            controller.Move(moveDir.normalized * movingSpeed * Time.deltaTime);
            //resets player running every cycle, when shift is pressed to prevent player speed to increase exponently
            resetPlayerRunning(isRunning);
        }    
    }
    private void setPlayerRunning(bool isRunning)
    {
        if (isRunning == true)
        {
            movingSpeed = movingSpeed * runningSpeedModifier;
        }
    }
    private void resetPlayerRunning(bool isRunning)
    {
        if (isRunning == true)
        {
            movingSpeed = movingSpeed / runningSpeedModifier;
        }
    }

    private void jumpPlayer()
    {
        if (isGrounded && movement.y < 0 && canMove == true)
        {
            movement.y = -0.1f;
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            if (isRunning == true)
            {
                movement.y = jumpForce * jumpForceModifier;
                isRunning = false;
            }   
            movement.y += Mathf.Sqrt(jumpForce * -3.0f * gravityModifier);
        }
        movement.y += gravityModifier * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
    }

}
