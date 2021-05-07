using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource dialogue;
    public AudioSource exploration;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "AK_MainMenu" || SceneManager.GetActiveScene().name == "AK_Credits" || SceneManager.GetActiveScene().name == "AK_Options")
        {
            dialogue.Stop();
            exploration.Stop();
            if (!menu.isPlaying)
                menu.Play();
        }
        else if (SceneManager.GetActiveScene().name == "A - Barman" || SceneManager.GetActiveScene().name == "B - Amélie" || SceneManager.GetActiveScene().name == "C - Willem" || SceneManager.GetActiveScene().name == "D - Nicolas" || SceneManager.GetActiveScene().name == "E - Téléphone" || SceneManager.GetActiveScene().name == "Epilogue")
        {
            exploration.Stop();
            menu.Stop();
            if (!dialogue.isPlaying)
                dialogue.Play();
        }
        else 
        {
            dialogue.Stop();
            menu.Stop();
            if (!exploration.isPlaying)
                exploration.Play();
        }
    }

    
}
