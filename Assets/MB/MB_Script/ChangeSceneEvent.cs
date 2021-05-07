using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ChangeSceneEvent : MonoBehaviour
{
	public void ChangeScene(string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
