using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//apparait dans le menu contextuel
[CreateAssetMenu(fileName = "New Profile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    //My... pour ne pas confondre avec les components name et text
    public string myName;
    private Sprite myPortrait;
    public AudioClip myVoice;

    //propriétés pour les émotions
    public Sprite MyPortrait
    {
        get 
        {
            SetEmotionType(Emotion);
            return myPortrait;
        }
    }

    //pour set les sprites des émotions
    [System.Serializable]
    public class EmotionPortraits
    {
        public Sprite standard;
        public Sprite happy;
        public Sprite curious;
        public Sprite thoughtful;
        public Sprite offended;
        public Sprite worried;
        public Sprite shocked;
        public Sprite arrogant;
        public Sprite angry;
        public Sprite hello;
        public Sprite dab;
    }
    public EmotionPortraits emotionPortraits;

    //Hide in Inspector
    public EmotionType Emotion { get; set; }

    //pour activer l'émotion qu'on veut afficher
    public void SetEmotionType(EmotionType newEmotion)
    {
        //pour passer à l'émotion suivante
        Emotion = newEmotion;
        switch (Emotion)
        {
            //Mise en place de toutes les émotions (liste à compléter si y a encore besoin)
            case EmotionType.Standard:
                myPortrait = emotionPortraits.standard;
                break;
            case EmotionType.Happy:
                myPortrait = emotionPortraits.happy;
                break;
            case EmotionType.Curious:
                myPortrait = emotionPortraits.curious;
                break;
            case EmotionType.Thoughtful:
                myPortrait = emotionPortraits.thoughtful;
                break;
            case EmotionType.Offended:
                myPortrait = emotionPortraits.offended;
                break;
            case EmotionType.Worried:
                myPortrait = emotionPortraits.worried;
                break;
            case EmotionType.Shocked:
                myPortrait = emotionPortraits.shocked;
                break;
            case EmotionType.Arrogant:
                myPortrait = emotionPortraits.arrogant;
                break;
            case EmotionType.Angry:
                myPortrait = emotionPortraits.angry;
                break;
            case EmotionType.Hello:
                myPortrait = emotionPortraits.hello;
                break;
            case EmotionType.Dab:
                myPortrait = emotionPortraits.dab;
                break;


        }

    }

}

//Liste Emotions (en dehors de la classe pour qu'on y est accès depuis n'importe où)
public enum EmotionType
{
    Standard,
    Happy,
    Curious,
    Thoughtful,
    Offended,
    Worried,
    Shocked,
    Arrogant,
    Angry,
    Hello,
    Dab
}
