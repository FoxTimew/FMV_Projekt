using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Tooltip("Start Game Scene name.")]
    public string startGame;

    [Tooltip("Options Scene name.")]
    public string optionsMenu;

    [Tooltip("Credits Scene name.")]
    public string creditsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene(creditsMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
