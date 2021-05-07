using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Tooltip("Start Game Scene name.")]
    public string startGame;

    [Tooltip("Options Scene name.")]
    public GameObject optionsMenu;

    [Tooltip("Credits Scene name.")]
    public GameObject creditsMenu;

    public GameObject mainMenu;

    private void Start()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(false);

    }

    public void CreditsMenu()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    
    public void MainMenu()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
