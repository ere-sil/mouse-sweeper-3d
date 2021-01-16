using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollapseTrigger : MonoBehaviour
{
    public static bool destroyBridgeA;
    public static bool destroyBridgeB;
    private bool collapseBridge;
    private float x = 5;

    // Start is called before the first frame update
    void Start()
    {
        destroyBridgeA = false;
        destroyBridgeB = false;
        collapseBridge = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyBridgeA == true | destroyBridgeB == true)
        {
            CountTime();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") & gameObject.CompareTag("BridgeCrash") & collapseBridge == true)
        {
            destroyBridgeA = true;
        }
        else if (other.gameObject.CompareTag("Player") & gameObject.CompareTag("BridgeCrashB") & collapseBridge == true)
        {
            destroyBridgeB = true;
        }
    }

    private void CountTime()
    {
        x = Timer.timerFunc(x);
        if (x <= 0)
        {
            collapseBridge = false;
            Debug.Log(collapseBridge);
            destroyBridgeA = false;
            destroyBridgeB = false;
        }
    }
}
