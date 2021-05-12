using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
	public bool[] boolDialogue = new bool[9];
	public bool end, epilogue, start;
	public DialogueBase[] dialogue;
	//-----PREMIERE PARTIE-------
	// 0 = Barman --> Vide apr�s
	// 1 = Am�lie Unlock --> Chez elle 
	// 2 = Willem Unlock--> 
	// 3 = Nicolas Unlock -->
	// 4 = TP dehors scene special --> Telephone --> Retour zone exploration
	//-----DEIXUEME PARTIE-------
	// 5 = Am�lie vue -->
	// 6 = Willem vue -->
	// 7 = Nicolas vue -->
	// 8 = Deuxi�me TELEPHONE -->
	//-----TABLEAU PARTIE-------

	//Sort automatiquement
	private bool[] willemClueBool = new bool[3];
	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

    public void LoadDialogue(string nomDeLaScene)
	{
		if (!start)
		{
			start = true;
			DialogueManager.instance.EnqueueDialogue(dialogue[16]);
		}
		if (epilogue)
		{
			DialogueManager.instance.EnqueueDialogue(dialogue[15]);
			return;
		}
		if (end)
		{
			DialogueManager.instance.EnqueueDialogue(dialogue[14]);
			return;
		}
		switch (nomDeLaScene)
		{
			case "Barman":
				if (!boolDialogue[0])
				{
					//Lancer dialogue;
					DialogueManager.instance.EnqueueDialogue(dialogue[0]);
					//Am�lie Zone Unlock
				}
				else 
				{
					DialogueManager.instance.EnqueueDialogue(dialogue[10]);
				}
				break;
			case "Am�lie":
				if (boolDialogue[0] && !boolDialogue[1])
				{
					// Lancer dialogue
					DialogueManager.instance.EnqueueDialogue(dialogue[1]);
					GameObject.Find("Inventory_Canvas").GetComponent<Enable_UI>().EnableUI(0);
					// Ajouter information dans le block
					// Willem zone unlock
				}
				else if (boolDialogue[0] && boolDialogue[1] && boolDialogue[2] && boolDialogue[3] && boolDialogue[4] && !boolDialogue[5])
				{
					//Lancer dialogue seconde partie
					DialogueManager.instance.EnqueueDialogue(dialogue[5]);
					//Mettre � jour le tableau
				}
				else
				{ 
					DialogueManager.instance.EnqueueDialogue(dialogue[11]);
				}
				break;
			case "Willem":
				if (boolDialogue[1] && !boolDialogue[2])
				{
					// Lancer dialogue
					DialogueManager.instance.EnqueueDialogue(dialogue[2]);
					GameObject.Find("Inventory_Canvas").GetComponent<Enable_UI>().EnableUI(1);
					// Ajouter information dans le block
					// D�bloquer Nicolas
				}
				else if (boolDialogue[0] && boolDialogue[1] && boolDialogue[2] && boolDialogue[3] && boolDialogue[4] && !boolDialogue[6])
				{
					//Lancer dialogue deuxi�me partie
					DialogueManager.instance.EnqueueDialogue(dialogue[6]);
					// mettre � jour le block
				}
				else
				{ 
					DialogueManager.instance.EnqueueDialogue(dialogue[12]);
				}
				break;
			case "Nicolas":
				if (boolDialogue[2] && !boolDialogue[3])
				{
					// Lancer dialogue
					DialogueManager.instance.EnqueueDialogue(dialogue[3]);
					GameObject.Find("Inventory_Canvas").GetComponent<Enable_UI>().EnableUI(2);
					// Ajouter information dans le block
					// Lancer scene dialogue t�l�phone
					// fin TP navigation
				}
				else if (boolDialogue[0] && boolDialogue[1] && boolDialogue[2] && boolDialogue[3] && boolDialogue[4] && !boolDialogue[7])
				{
					//Lancer dialogue deuxi�me partie
					DialogueManager.instance.EnqueueDialogue(dialogue[7]);
					//Mettre � jour le block
				}
				else
				{ 
					DialogueManager.instance.EnqueueDialogue(dialogue[13]);
				}
				break;
			default:
				if (!boolDialogue[4])
				{
					DialogueManager.instance.EnqueueDialogue(dialogue[4]);
				}
				else if(!boolDialogue[10])
				{
					DialogueManager.instance.EnqueueDialogue(dialogue[8]);
				}
				else
				{ 
					DialogueManager.instance.EnqueueDialogue(dialogue[9]);
				}
				break;
		}

	}
	public void ClueBool(int index)
	{
		willemClueBool[index] = true;
		bool test = true;
		for (int i = 0; i < willemClueBool.Length; i++)
		{
			if (!willemClueBool[i]) test = false;
		}
		if (test) boolDialogue[9] = true;
	}
}
