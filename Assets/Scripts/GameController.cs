using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
    public static bool gamePlaying;
    public int Score;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        gameOverScreen.SetActive(false);
        BeginGame();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            gamePlaying = false;
            RestartScreen();
        }
        else
        {
            lives = player.GetComponent<PlayerController>().currentHearts;
        }
    }

    void BeginGame()
    {
        gamePlaying = true;

    }

    void MouseIsDead()
    {
        if (player == null)
        {

        }
    }
    public void RestartScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(FindObjectOfType<AudioManager>().gameObject, 2);
        calculateScore();
        scoreText.text = Score.ToString();
        gameOverScreen.SetActive(true);

    }

    private int calculateScore()
    {
        int totalScore = Score;
        totalScore += (500 * lives);
        //pieces of cheese x 200
        return totalScore;
    }
}

