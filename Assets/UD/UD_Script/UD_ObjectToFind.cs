using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_ObjectToFind : MonoBehaviour
{
    public GameObject UIToTriggerOnFind;

    public void ObjectFinded()
    {
        //Ajouter L'objet � l'inventaire

        UIToTriggerOnFind.SetActive(true);
    }
}
