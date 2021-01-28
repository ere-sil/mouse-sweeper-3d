using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public string mainMenu;
    public string levelSelectionScene;
    public string monumentScene;
    public string twoBridgesScene;
    public string twoCratesScene;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button mainMenuButton;
    public Button resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(levelSelectionScene);
    }

    public void MonumentLevel()
    {
        SceneManager.LoadScene(monumentScene);
    }

    public void TwoBridgesLevel()
    {
        SceneManager.LoadScene(twoBridgesScene);
    }

    public void TwoCratesLevel()
    {
        SceneManager.LoadScene(twoCratesScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void ResumeGame()
    {
        GameController.gamePlaying = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
