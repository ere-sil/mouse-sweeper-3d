using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollapse : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BridgeCollapseTrigger.destroyBridgeA == true & gameObject.CompareTag("BridgeCrash"))
        {
            rb.isKinematic = false;
        }
        else if (BridgeCollapseTrigger.destroyBridgeB == true & gameObject.CompareTag("BridgeCrashB"))
        {
            rb.isKinematic = false;
        }
    }
}
