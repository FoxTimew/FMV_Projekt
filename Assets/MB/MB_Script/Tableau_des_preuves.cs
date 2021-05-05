using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tableau_des_preuves : MonoBehaviour
{
    [SerializeField]
    private Dropdown[] dd;

	[SerializeField]
	private int[] ddGoodValue;

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
		}
		else
		{ 
			//Lancer dialogue...
		}
	}
}
