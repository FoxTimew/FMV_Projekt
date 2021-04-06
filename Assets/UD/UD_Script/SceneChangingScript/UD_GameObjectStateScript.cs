using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_GameObjectStateScript : MonoBehaviour
{
    public void EnableGameObject()
    {
        gameObject.SetActive(true);
    }
    
    public void DiseableGameObject()
    {
        gameObject.SetActive(false);
    }
}