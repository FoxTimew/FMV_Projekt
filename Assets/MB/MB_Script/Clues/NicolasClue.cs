using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicolasClue : MonoBehaviour
{
	public void AddClue(string clueText)
	{
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(true);
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.AddClue(clueText, "Nicolas");
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(false);
	}
}
