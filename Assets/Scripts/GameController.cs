using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button mainMenuButton;
    public Button resumeButton;
    public static bool gamePlaying;
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(gamePlaying);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePlaying = false;
            RestartScreen();
        }
        Debug.Log(gamePlaying);
    }

    void BeginGame()
    {
        gamePlaying = true;
        TimerController.instance.BeginTimer();
    }

    public void RestartScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
    }
}

