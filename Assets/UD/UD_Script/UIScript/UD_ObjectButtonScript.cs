using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UD_ObjectButtonScript : MonoBehaviour
{
    public string descritptionToShow;

    private GameObject textHolder;

    private void Start()
    {
        textHolder = GameObject.Find("Description");
        textHolder.GetComponent<Text>().text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowDescription();
        }
    }
    public void ShowDescription()
    {
        print("click");
        textHolder.GetComponent<Text>().text = descritptionToShow;
    }
}
