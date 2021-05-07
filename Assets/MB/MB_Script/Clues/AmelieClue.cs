using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmelieClue : MonoBehaviour
{
	public void AddClue(string clueText)
	{
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(true);
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.AddClue(clueText, "Amélie");
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(false);
	}
}
