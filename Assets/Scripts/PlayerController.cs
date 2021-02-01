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

    public bool hasDoubleJumpPU;
    public bool hasShieldPU;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mineTile = GameObject.Find("MineTrigger");
        freeTile = GameObject.Find("NoMineTrigger");
        hasDoubleJumpPU = false;
        hasShieldPU = false;

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
        FindObjectOfType<AudioManager>().sounds[7].volume = 0;
        Destroy(player);

    }
    public void lifeUp()
    {
       if(currentHearts<maxHearts) currentHearts++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoubleJumpPU"))
        {
            hasDoubleJumpPU = true;
            FindObjectOfType<AudioManager>().Play("Pop");
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("ShieldPU"))
        {
            hasShieldPU = true;
            transform.localScale = new Vector3(3, 3, 3);
            FindObjectOfType<AudioManager>().Play("Pop");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("MetalDetector"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(0.211f, -0.684f, 1.332f);
            other.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
    }
}