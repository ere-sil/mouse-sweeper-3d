using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mincer : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void ActivateMincer()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
           Vector3 currentpos=transform.position;
            transform.position = new Vector3(currentpos.x - 0.05f, currentpos.y, currentpos.z);
        }
    }
}
