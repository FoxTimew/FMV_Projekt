using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UD_SceneChangingScript : MonoBehaviour
{
    [HideInInspector] public string nameOfNextScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nameOfNextScene);
    }
}
