using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    private AudioManager audioM;
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {

        if (Input.GetMouseButton(1)) pressed = true;
        else pressed = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.gameObject.transform.parent.CompareTag("Player") && pressed)
        {
            if (other.gameObject.CompareTag("isMine"))
            {
                audioM.Play("MetalDetected");
            }
            else
            {
                audioM.Play("NoMetalDetected");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!pressed)
        {
            audioM.Stop("MetalDetected");
            audioM.Stop("NoMetalDetected");
        }
        if (other.gameObject.CompareTag("isMine"))
        {
            audioM.Stop("MetalDetected");
        }
       

    }
}
