using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//menu contextuel
[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogues/With Choices")]
//on fait d�river de DialogueBase pour avoir tout ce qui a dans un dialogue normal  
 public class DialogueOptions : DialogueBase
{
    [TextArea(2, 10)]
    public string questionText;

    [System.Serializable]
    public class Options
    {
        public string buttonName;

        //pour envoyer � un nouveau dialogue apr�s un choix
        public DialogueBase nextDialogue;
        
        public UnityEvent myEvent;
        
    }
    public Options[] optionsInfo;
}
