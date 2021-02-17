using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private GameController gameController;
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
        gameController = FindObjectOfType<GameController>();
        player = GameObject.FindWithTag("Player");
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
        Destroy(player);

    }
    public void lifeUp()
    {
        if (currentHearts < maxHearts & currentHearts > 0)
        {
            currentHearts++;
        }
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
            Destroy(other);
            FindObjectOfType<AudioManager>().Play("Pop");
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(0.28f, 0, 0.33f);
            other.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, -102.024F, 89.064F));
            
        }
        else if (other.gameObject.CompareTag("MetalDetector"))
        {
            gameController.detectorRemaining.SetActive(true);
            Destroy(other);
            FindObjectOfType<AudioManager>().Play("Pop");
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(0.278f, -0.8f, 1.6203f);
            other.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-25.177f, 0, 0));
        }
    }
}