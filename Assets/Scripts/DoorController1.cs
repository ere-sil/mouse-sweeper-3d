using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorController1 : MonoBehaviour
{
    //these variables control doors  with timers
    public float closeTime;
    private float closeTimeTool;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Door"))
        {
            OpenTriggerDoors(other);
        }
    }

    //closes door after a time invoked as closeTime
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Door"))
        {
            Invoke("CloseTriggerDoors", closeTime);
        }
    }

    //checks door for GameObjects name, and then runs it's animator and right animation for opening door
    private void OpenTriggerDoors(Collider other)
    {
        //double doors right hand side opening animator
        if (GameObject.Find("DoorTriggerRight") & other.gameObject.CompareTag("Player"))
        {
            Animator anim = GetComponentInChildren<Animator>();
            anim.ResetTrigger("RightDoorClose");
            anim.SetTrigger("RightDoorOpen");
        }

        //double doors left hand side opening animator
        if (GameObject.Find("DoorTriggerLeft") & other.gameObject.CompareTag("Player"))
        {
            Animator anim = GetComponentInChildren<Animator>();
            anim.SetTrigger("LeftDoorOpen");
            anim.ResetTrigger("LeftDoorClose");
        }
    }

    //closes the door by starting an animation that closes the door
    private void CloseTriggerDoors()
    {
        //double doors right hand side closing animator
        if (GameObject.Find("DoorTriggerRight"))
        {
            Animator anim = GetComponentInChildren<Animator>();
            anim.ResetTrigger("RightDoorOpen");
            anim.SetTrigger("RightDoorClose");
        }

        //double doors left hand side closing animator
        if (GameObject.Find("DoorTriggerLeft"))
        {
            Animator anim = GetComponentInChildren<Animator>();
            anim.ResetTrigger("LeftDoorOpen"); 
            anim.SetTrigger("LeftDoorClose");
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
