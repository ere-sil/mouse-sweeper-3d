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
}
