using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    //fonction pour passer au dialogue suivant (� rajouter dans le OnClick)
    public void GetNextLine()
    {
        DialogueManager.instance.DequeueDialogue();
    }
}
