using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//doc Unity Event Systems
public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogueBase myDialogue;

    //ce qui se passe quand on clique sur un button
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        eventHandler.Invoke();
        //ferme options quand on clique sur un button
        DialogueManager.instance.CloseOptions();

        //trigger myDialogue
        if (myDialogue != null)
        {
            DialogueManager.instance.EnqueueDialogue(myDialogue);
        }
    }

}
