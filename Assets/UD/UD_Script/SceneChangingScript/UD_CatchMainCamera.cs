using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_CatchMainCamera : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if(canvas.worldCamera == null)
        {

            canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }
}
