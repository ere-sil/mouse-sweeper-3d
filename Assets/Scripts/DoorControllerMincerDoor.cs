using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerMincerDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenMincerDoor();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CloseMincerDoor();
        }
    }

    private void OpenMincerDoor()
    {
        //A Door for letting the Mice Mincer out from it's cave, opening animator
        if (gameObject == GameObject.Find("MincerDoor"))
        {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.ResetTrigger("CloseMincerDoor");
            anim.SetTrigger("OpenMincerDoor");
        }
    }
    private void CloseMincerDoor()
    {
        //A Door for letting the Mice Mincer out from it's cave, closing animator
        if (gameObject == GameObject.Find("MincerDoor"))
        {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.ResetTrigger("OpenMincerDoor");
            anim.SetTrigger("CloseMincerDoor");
        }
    }

}
