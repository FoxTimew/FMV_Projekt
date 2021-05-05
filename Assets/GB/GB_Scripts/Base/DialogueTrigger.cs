using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueBase dialogue;

    //déclenche le dialogue
    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void Update()
    {
        //ne pas map sur Space et Enter pour ne pas push le button
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TriggerDialogue();
        }
    }
}
