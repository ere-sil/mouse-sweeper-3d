using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip metalDetected;
    public AudioClip noMetalDetected;
    // Start is called before the first frame update
    void Start()
    {
       audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject != null)
        {
            audioSource.Stop();
        }
    }
    public void PlayMetal()
    {
        audioSource.PlayOneShot(metalDetected);
    }

    public void PlayNoMetal()
    {
        audioSource.PlayOneShot(noMetalDetected);
    }
    public void StopSounds()
    {
        audioSource.Stop();
    }
}
