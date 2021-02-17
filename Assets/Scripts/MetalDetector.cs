using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    private AudioManager audioM;
    private bool pressed;
    private float timeremaining;
    private GameController gameController;
    public UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        audioM = FindObjectOfType<AudioManager>();
        timeremaining = 10f;
    }
    private void Update()
    {
        image.fillAmount = timeremaining/10;
        if (Input.GetMouseButton(1)) pressed = true;
        else pressed = false;
        if (pressed)
        {
            timeremaining -= Time.deltaTime;
        }
        if (timeremaining <= 0)
        {
            gameController.detectorRemaining.SetActive(false);
            audioM.Stop("MetalDetected");
            audioM.Stop("NoMetalDetected");
            Destroy(transform.parent.gameObject);
        }
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
