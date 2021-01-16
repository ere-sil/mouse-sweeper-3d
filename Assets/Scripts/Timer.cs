using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float timerFunc(float timeLeft)
    {
        timeLeft -= Time.deltaTime;
        return timeLeft;
    }
}
