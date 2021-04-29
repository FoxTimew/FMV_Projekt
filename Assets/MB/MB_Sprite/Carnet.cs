using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carnet : MonoBehaviour
{
	[SerializeField]
	private GameObject ficheRecap;

	[SerializeField]
	private Image profilPicture;

	[SerializeField]
	private Text clue, nameText;

	private string[] characterName = {"Nicolas", "Am�lie", "Wilhem", "Sophie", "Enqu�te" };

	[SerializeField]
	private Sprite[] charactersPictures = new Sprite[5];

	private string[] cluesOfCharacter = new string[5];

	private void Start()
	{
		for (int i = 0; i < 10; i++)
		{
			AddClue("Text Num�ro" + i, "Nicolas");
			AddClue("Text Num�ro" + i + 10, "Am�lie");
			AddClue("Text Num�ro" + i + 100, "Wilhem");
			AddClue("Text Num�ro" + i + 1000, "Sophie");
			AddClue("Text Num�ro" + i + 10000, "Enquete");
		}
	}

	public void AddClue(string text, string character)
	{
		switch (character)
		{
			case "Nicolas":
				cluesOfCharacter[0] = cluesOfCharacter[0] + "\n" + text;
				break;
			case "Am�lie":
				cluesOfCharacter[1] = cluesOfCharacter[1] + "\n" + text;
				break;
			case "Wilhem":
				cluesOfCharacter[2] = cluesOfCharacter[2] + "\n" + text;
				break;
			case "Sophie":
				cluesOfCharacter[3] = cluesOfCharacter[3] + "\n" + text;
				break;
			default:
				cluesOfCharacter[4] = cluesOfCharacter[4] + "\n" + text;
				break;
		}
	}

	public void ClueUIUpdate(int index)
	{
		profilPicture.sprite = charactersPictures[index];

		nameText.text = characterName[index];

		clue.text = cluesOfCharacter[index];

		ficheRecap.SetActive(true);
	}

	public void CloseWindow()
	{
		ficheRecap.SetActive(false);
	}
}
