using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug_ChangeState : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) SceneManager.LoadScene(sceneToLoad);
    }
}
