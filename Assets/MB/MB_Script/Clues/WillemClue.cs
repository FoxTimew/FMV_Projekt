using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillemClue : MonoBehaviour
{
	public void AddClue(string clueText)
	{
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(true);
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.AddClue(clueText, "Willem");
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(false);
	}
}
