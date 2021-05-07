using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tableau_des_preuves : MonoBehaviour
{
    [SerializeField]
    private Dropdown[] dd;

	[SerializeField]
	private int[] ddGoodValue;

	[SerializeField]
	private Text text;

	[SerializeField]
	GameObject fond;

	public void Validate()
	{
		bool good = true;
		for (int i = 0; i < dd.Length; i++)
		{
			if (dd[i].value != ddGoodValue[i])
			{
				good = false;
				i = dd.Length;
			}
		}
		if (good)
		{
			//Lancer la dernière scène
			GameObject.Find("Manager").GetComponent<Manager>().end = true;
			SceneManager.LoadScene("D - Nicolas");
			fond.SetActive(false);
		}
		else
		{
			//Lancer dialogue...
			text.gameObject.SetActive(true);
			StartCoroutine(TextDelay());
		}
	}

	IEnumerator TextDelay()
	{
		yield return new WaitForSeconds(3);
		text.gameObject.SetActive(false);
	}
}
