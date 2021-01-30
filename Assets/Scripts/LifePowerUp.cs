using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    private bool isAvailable;

    private void Start()
    {
        isAvailable = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp(other.gameObject.GetComponent<PlayerController>());
        }
    }
    private void PickUp(PlayerController pc)
    {
        if (pc.currentHearts < pc.maxHearts&& isAvailable)
        {
            isAvailable = false;
            FindObjectOfType<AudioManager>().Play("Heal");
            FindObjectOfType<AudioManager>().Play("HeartBeat");
            pc.lifeUp();
            StartCoroutine(coolDown());
            Destroy(gameObject);
            
        }

    }
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(2);
        isAvailable = true;
    }

}
