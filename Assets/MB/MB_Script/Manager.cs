using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	public bool[] boolDialogue = new bool[9];
	public DialogueBase[] dialogue;
	//-----PREMIERE PARTIE-------
	// 0 = Barman --> Vide après
	// 1 = Amélie Unlock --> Chez elle 
	// 2 = Willem Unlock--> 
	// 3 = Nicolas Unlock -->
	// 4 = TP dehors scene special --> Telephone --> Retour zone exploration
	//-----DEIXUEME PARTIE-------
	// 5 = Amélie vue -->
	// 6 = Willem vue -->
	// 7 = Nicolas vue -->
	// 8 = Deuxième TELEPHONE -->
	//-----TABLEAU PARTIE-------

	//Sort automatiquement

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	public void LoadDialogue(string nomDeLaScene)
	{
		switch (nomDeLaScene)
		{
			case "Barman":
				if (!boolDialogue[0])
				{
					//Lancer dialogue;
					DialogueManager.instance.EnqueueDialogue(dialogue[0]);
					//Amélie Zone Unlock
				}
				break;
			case "Amélie":
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
					//Mettre à jour le tableau
				}
				break;
			case "Willem":
				if (boolDialogue[1] && !boolDialogue[2])
				{
					// Lancer dialogue
					DialogueManager.instance.EnqueueDialogue(dialogue[2]);
					GameObject.Find("Inventory_Canvas").GetComponent<Enable_UI>().EnableUI(1);
					// Ajouter information dans le block
					// Débloquer Nicolas
				}
				else if (boolDialogue[0] && boolDialogue[1] && boolDialogue[2] && boolDialogue[3] && boolDialogue[4] && !boolDialogue[6])
				{ 
					//Lancer dialogue deuxième partie
					DialogueManager.instance.EnqueueDialogue(dialogue[6]);
					// mettre à jour le block
				}
				break;
			case "Nicolas":
				if (boolDialogue[2] && !boolDialogue[3])
				{
					// Lancer dialogue
					DialogueManager.instance.EnqueueDialogue(dialogue[3]);
					GameObject.Find("Inventory_Canvas").GetComponent<Enable_UI>().EnableUI(2);
					// Ajouter information dans le block
					// Lancer scene dialogue téléphone
					// fin TP navigation
				}
				else if (boolDialogue[0] && boolDialogue[1] && boolDialogue[2] && boolDialogue[3] && boolDialogue[4] && !boolDialogue[7])
				{ 
					//Lancer dialogue deuxième partie
					DialogueManager.instance.EnqueueDialogue(dialogue[7]);
					//Mettre à jour le block
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
}
