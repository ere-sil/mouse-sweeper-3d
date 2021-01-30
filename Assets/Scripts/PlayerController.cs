using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject mineTile;
    public GameObject freeTile;
    private CharacterController controller;
    //lives system
    public int currentHearts = 3;
    public int maxHearts = 3;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;


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
        CheckLives();//check if the mouse is alive

        //Cannot be more hearts than maxHearts
        if (currentHearts > maxHearts)
        {
            currentHearts = maxHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            //Fill or not the hearts
            if (i < currentHearts)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            //Just display the needed hearts
            if (i < maxHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void CheckLives()
    {
        if (currentHearts == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(player);

    }
}