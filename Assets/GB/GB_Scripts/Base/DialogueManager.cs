 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Pause de ponctuation
    private readonly List<char> punctuationCharacters = new List<char>
    {
        //liste des caractères qui font une pause
        '.',
        ',',
        //'!',
        //'?'

    };
   
    //références au Dialogue Manager
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    //références à l'UI dans l'Inspector
    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    //public Image dialoguePortrait;

    //variable pour la coroutine TypeWriterEffect
    public float delayType = 0.001f;

    //références CharacterPortrait
    public Image[] characterPortraits;

    //variable pour la pause ponctuation
    public float delayPunctuation = 0.5f;

    //Queue > Array / First In First Out
    // les infos sont appelées dans l'ordre où on les charge
    public Queue<DialogueBase.Info> dialogueInfo;

    //références options
    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    private bool inDialogue;
    public GameObject[] optionButtons;
    private int optionsAmount;
    public Text questionText;

    //pour l'Auto Complete Text
    public bool isCurrentlyTyping;
    private string completeText;

    //référence NameHolder
    public Transform nameHolder;

    private DialogueBase currentDialogue;

    public void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    //récupère les infos de la classe DialogueBase
    public void EnqueueDialogue(DialogueBase db)
    {
        //vérifie si on est dans un dialogue
        if (inDialogue) return;
        inDialogue = true;

        //pour fixer qui parle
        currentDialogue = db;
        
        //active boite de dialogue
        dialogueBox.SetActive(true);

        //pour tout clean avant de commencer à queue
        dialogueInfo.Clear();

        //affiche portraits
        SetCharacterPortraits(db);

        //options rangées
        OptionsParser(db);

        //charge les infos dans la queue
        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();

    }

    //pour enlever les infos une par une dans l'ordre (FIFO) 
    public void DequeueDialogue()
    {
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            //tout ce qu'il y a après le return n'est pas utilisé
            return;
        }
        
        //pour supprimer la boite de dialogue lorsqu'il n'y a plus de lignes à insérer dedans
        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            //tout ce qu'il y a après le return n'est pas utilisé
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;

        //change la postion du nom
        nameHolder.position = characterPortraits[GetCurrentCharacterIndex(info)].gameObject.transform.position - new Vector3(0,25);

        //dialogueName.text = info.myName;
        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        //dialoguePortrait.sprite = info.myPortrait;

        

        //change Emotion et ensuite appelle myPortrait
        info.ChangeEmotion();
        //assombrit personnages
        DarkenOtherPortraits(info);
        //dialoguePortrait.sprite = info.character.MyPortrait;
        characterPortraits[GetCurrentCharacterIndex(info)].sprite = info.character.MyPortrait;

        //Retire tous les textes avant d'en insérer un nouveau  
        dialogueText.text = "";
        
        //Type Writing Effect
        StartCoroutine(TypeText(info));
    }

    //assombrit les persos qui ne parlent pas
    private void DarkenOtherPortraits(DialogueBase.Info info)
    {
        //loop à travers tous les persos
        for (int i = 0; i < characterPortraits.Length; i++)
        {
            //ce perso parle
            if (i == GetCurrentCharacterIndex(info))
            {
                //FFFFFF = Blanc dans Unity (voir la roue des couleurs)
                characterPortraits[i].color = hexToColor("FFFFFF");
                //agrandit le perso qui parle
                characterPortraits[i].rectTransform.localScale = new Vector3(0.15f, 0.15f);

            }
            //ce perso ne parle pas
            else 
            {
                characterPortraits[i].color = hexToColor("5C5C5C");
                //taille normale (perso qui ne parle pas)
                characterPortraits[i].rectTransform.localScale = new Vector3(0.12f, 0.12f);
            }
        }
    }
        

    private int GetCurrentCharacterIndex(DialogueBase.Info info)
    {
        //loop parmi les 2 persos
        for (int i = 0; i < currentDialogue.characters.Length; i++)
        {
            //vérifie si le perso est bien celui de la liste
            if (info.character == currentDialogue.characters[i])
            {
                return i;
            }
        }
        Debug.Log("Error ! Character is not in the list");
        return 0;
    }

    //Fonction pour mettre en place les portraits
    private void SetCharacterPortraits(DialogueBase db)
    {
        //loop parmi tous les portraits
        for (int i = 0; i < characterPortraits.Length; i++)
        {
            //characterPortraits[i].sprite = db.characters[i].MyPortrait;
            //au lieu de My Portrait qui est l'émotion actuel, on utilise l'émotion Standard par défaut
            characterPortraits[i].sprite = db.characters[i].emotionPortraits.standard;

        }

    }

    //Fonction pause ponctuation
    // c = caractères ou lettres
    private bool CheckPunctuation(char c)
    {
        if (punctuationCharacters.Contains(c))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    
    //Coroutine pour le Type Writer Effect
    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        //dialogueText.text = "";
        //ajoute les lettres une par une
        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delayType);
            dialogueText.text += c;
            //yield return null;
            
            AudioManager.instance.PlayClip(info.character.myVoice);

            if (CheckPunctuation(c))
            {
                yield return new WaitForSeconds(delayPunctuation);
            }
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    public void EndofDialogue()
    {
        //désactive boite de dialogue
        dialogueBox.SetActive(false);
        //on est plus dans un dialogue
        inDialogue = false;

        OptionsLogic();

    }

    //active Options dialogue
    private void OptionsLogic()
    {
        
        if (isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
        }
    }

    //ferme options quand on clique sur un button
    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
    }

    //options rangées
    private void OptionsParser(DialogueBase db) 
    {
        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;

            //on désactive tous les boutons
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }

            //puis on active ceux qu'on utilise
            for (int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);

                // vérifier qu'il n'y a qu'un seul enfant Text par button
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = dialogueOptions.optionsInfo[i].buttonName;

                //on équivaut UnityEvent et myEvent
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;

                //active myButton
                //vérifie s'il y a un dialogue dans la liste
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    //crée un nouveau dialogue
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }

        else
        {
            isDialogueOption = false;
        }
    }


    //assombrissement des portraits
    //Hex Color Codes
    public Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");
        hex = hex.Replace("#", "");
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }
    //
}
