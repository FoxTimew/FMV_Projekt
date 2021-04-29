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
    //tout ce qu'on déclare ici, on y a accès dans EventBehaviour
    
    public GameObject testGameObject;

    public AudioSource audioSource;



}
