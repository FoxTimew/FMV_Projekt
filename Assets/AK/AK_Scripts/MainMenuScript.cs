using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Tooltip("Start Game Scene.")]
    public string startGame;

    [Tooltip("Options Scene.")]
    public string optionsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
