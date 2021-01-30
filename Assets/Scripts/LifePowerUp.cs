using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp(other.gameObject.GetComponent<PlayerController>());
        }
    }
    private void PickUp(PlayerController pc)
    {
        if (pc.currentHearts < pc.maxHearts)
        {
            pc.currentHearts ++;
            Destroy(gameObject);
        }

    }
}
