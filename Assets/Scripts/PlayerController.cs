using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject mineTile;
    public GameObject freeTile;
    private CharacterController controller;

    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mineTile = GameObject.Find("MineTrigger");
        freeTile = GameObject.Find("NoMineTrigger");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
