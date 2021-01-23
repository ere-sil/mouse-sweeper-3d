using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string mainMenu;
    public string levelSelectionScene;
    public string monumentScene;
    public string twoBridgesScene;
    public string twoCratesScene;
    public string tutorial1;
    public Button restartButton;
    public Button mainMenuButton;
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
    public void Tutorial1()
    {
        SceneManager.LoadScene(tutorial1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
