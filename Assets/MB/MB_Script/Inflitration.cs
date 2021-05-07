using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflitration : MonoBehaviour
{
    public GameObject window;
    void Start()
    {
        StartCoroutine(StartInfiltration());
    }

    private IEnumerator StartInfiltration()
    {
        yield return new WaitForEndOfFrame();
        if (GameObject.Find("Manager").GetComponent<Manager>().boolDialogue[6] && !GameObject.Find("Manager").GetComponent<Manager>().boolDialogue[9])
        {
            window.SetActive(true);
        }
    }
}
