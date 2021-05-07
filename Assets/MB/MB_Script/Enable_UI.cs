using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Enable_UI : MonoBehaviour
{
	public Sprite[] sprite = new Sprite[3];
	public GameObject[] gameObjectName = new GameObject[3];

	public GameObject[] AmelieOptions;
	public GameObject[] WilhemOptions;
	public GameObject[] NicoOptions;
	public GameObject[] MapPoint;

	public Text[] suspectText;
	public string[] suspectName;

	public Button validateButton;
	public void EnableUI(int index)
	{
		//Carnet
		gameObjectName[index].GetComponent<Image>().sprite = sprite[index];
		gameObjectName[index].GetComponentInChildren<Button>().interactable = true;

		//tableau des preuves
		EnableOption(index);

		//Map
		MapPoint[index].SetActive(true);
	}

	private void EnableOption(int index)
	{
		switch (index)
		{
			case 0:
				foreach (GameObject g in AmelieOptions)
				{
					g.SetActive(true);
				}
				break;
			case 1:
				foreach (GameObject g in WilhemOptions)
				{
					g.SetActive(true);
				}
				break;
			default:
				foreach (GameObject g in NicoOptions)
				{
					g.SetActive(true);
				}
				validateButton.interactable = true;
				break;
		}
		suspectText[index].text = suspectName[index];
	}
}
