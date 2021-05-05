using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField]
    private string nomDeLaScene;
    void Start()
    {
        StartCoroutine(StartNextFrame());
    }

    IEnumerator StartNextFrame()
    {
        yield return new WaitForEndOfFrame();
        GameObject.Find("Manager").GetComponent<Manager>().LoadDialogue(nomDeLaScene);
    }
}
