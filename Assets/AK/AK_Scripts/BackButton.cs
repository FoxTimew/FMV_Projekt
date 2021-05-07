using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string backScene;

    public void Back()
    {
        SceneManager.LoadScene(backScene);
    }
}
