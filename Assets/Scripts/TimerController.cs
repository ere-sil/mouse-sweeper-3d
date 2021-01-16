using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;


    public TimeSpan timePlaying;
    public bool timerGoing;
    
    public float timeGiven;
    public float elapsedTime;
    public float timerTime;

    public void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    public void Start()
    {
        //timeCounter.text = "00:00.0";
        //timerGoing = true;
    }


    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        timeCounter.color = Color.white;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timerTime = timeGiven - elapsedTime;

            timePlaying = TimeSpan.FromSeconds(timerTime);
            timeCounter.text = timePlaying.ToString("mm':'ss'.'f");

            if(timerTime<=0)
            {
                timeCounter.color = Color.red;
            }
            else if(timerTime<=30)
            {
                Color newColor = new Color(1f, 0.49f, 0f);
                timeCounter.color = newColor;
            }
            else if (GameController.gamePlaying == false)
            {
                EndTimer();
            }

            yield return null;
        }
    }

    // Update is called once per frame
    /*public void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        if(currentTime <= 10)
        {
            timerText.color = Color.red;
        }
        if(currentTime > 0)
        {
            currentTime = 0;
        }
    }*/
}
