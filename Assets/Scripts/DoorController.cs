using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //these variables control doors  with timers or countTime booleans
    bool countTime;
    public float closeTime;
    private float closeTimeTool;
    
    

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("StartDoorRight1") & gameObject.CompareTag("Door"))
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            if (other.gameObject.CompareTag("Ground") == false)
            {
                anim.ResetTrigger("RightDoorClose");
                anim.SetTrigger("RightDoorOpen");
            }
        }
        if (GameObject.Find("StartDoorLeft1") & gameObject.CompareTag("Door"))
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            if (other.gameObject.CompareTag("Ground") == false)
            {
                anim.SetTrigger("LeftDoorOpen");
                anim.ResetTrigger("LeftDoorClose");
            }
        }
    }

    //closes door after a time or instantly
    private void OnTriggerExit(Collider other)
    {
        if (countTime == true)
        {
            Invoke("CloseDoors", closeTime);
            countTime = false;
        }

        else if (countTime == false)
        {
            CloseDoors();
        }
    }

    //closes the door by starting an animation that closes the door
    private void CloseDoors()
    {
        Debug.Log("Suljetaan....");
        GameObject rightDoor = GameObject.Find("StartDoorRight1");
        GameObject leftDoor = GameObject.Find("StartDoorLeft1");
        if (rightDoor)
        {
            Animator anim = rightDoor.GetComponent<Animator>();
            anim.SetTrigger("RightDoorClose");
            anim.ResetTrigger("RightDoorOpen");
        }
        if (leftDoor)
        {
            Animator anim = leftDoor.GetComponentInChildren<Animator>();
            anim.SetTrigger("LeftDoorClose");
            anim.ResetTrigger("LeftDoorOpen");
        }
    }


    //counts time, that can be used to close a door
    private void CountCloseTime()
    {
        closeTimeTool = closeTime;
        closeTimeTool = Timer.timerFunc(closeTimeTool);
        
        if (closeTimeTool <= 0)
        { 
            closeTimeTool = closeTime;
        }

        Debug.Log(closeTime);
    }

}
