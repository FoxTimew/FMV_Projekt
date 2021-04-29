using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//apparait dans le menu contextuel
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/No Choices")]
public class DialogueBase : ScriptableObject
{
    [Header("Insert Character Here")]
    //créer x (2 actuellement) emplacements de persos pour chaque SO Dialogue
    public CharacterProfile[] characters = new CharacterProfile[2];
    
    //visible dans l'inspecteur
    [System.Serializable]
    public class Info
    {
        //attention à l'ordre qui est le même dans l'Inspector
        public CharacterProfile character;
        public EmotionType characterEmotion;
        //My... pour ne pas confondre avec les components name et text
        //public string myName;
        //public Sprite myPortrait;
        [TextArea(4, 8)]
        public string myText;


        public void ChangeEmotion()
        {
            //pour l'assigner à celle qui est mise dans l'inspecteur
            character.Emotion = characterEmotion;
        }
    }

    [Header("Insert Dialogue Here")]
    public Info[] dialogueInfo;
}
