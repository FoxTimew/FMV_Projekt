using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClueInfiltration : MonoBehaviour
{
	public string[] clueText;
	public void Action(int index)
	{
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(true);
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.AddClue(clueText[index], "Willem");
		GameObject.Find("Manager").GetComponent<Manager>().ClueBool(index);
		GameObject.Find("Inventory_Canvas").GetComponent<Test>().carnet.gameObject.SetActive(false);
	}
}
