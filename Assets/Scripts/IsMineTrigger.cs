using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMineTrigger : MonoBehaviour
{
    private GameObject player;
    private bool freeTile;
    private bool mineTile;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        freeTile = gameObject.CompareTag("noMine");
        mineTile = gameObject.CompareTag("isMine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") & freeTile == true)
        {
            Debug.Log("No mine here");
        }
        else if (other.gameObject.CompareTag("Player") & mineTile == true)
        {
            Debug.Log("Triggered Explosion");
            Destroy(player);
        }
    }
}
