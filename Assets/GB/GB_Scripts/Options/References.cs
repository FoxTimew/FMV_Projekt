using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Access Scene Objects Here
    //tout ce qu'on d�clare ici, on y a acc�s dans EventBehaviour
    
    public GameObject testGameObject;

    public AudioSource audioSource;



}
