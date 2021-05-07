using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Point : MonoBehaviour
{
    public int boolIndex;
    public string gameObjectName;
    public GameObject button, text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnablePoint());
    }

    IEnumerator EnablePoint()
    {
        yield return new WaitForEndOfFrame();
        if (GameObject.Find(gameObjectName).GetComponent<Manager>().boolDialogue[boolIndex])
        {
            button.SetActive(true);
            text.SetActive(true);
        }
    }
}
