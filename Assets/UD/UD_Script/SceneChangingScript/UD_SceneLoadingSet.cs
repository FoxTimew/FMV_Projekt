using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_SceneLoadingSet : MonoBehaviour
{
    public string sceneToLoad;
    public string animToPlay;

    GameObject fade;

    UD_SceneChangingScript SGC;
    UD_AnimTriggerScript ATS;

    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade");
        SGC = fade.GetComponent<UD_SceneChangingScript>();
        ATS = fade.GetComponent<UD_AnimTriggerScript>();
    }

    public void ChangeScene()
    {
        fade.SetActive(true);
        SGC.nameOfNextScene = sceneToLoad;
        ATS.animationName = animToPlay;
        ATS.ChangeAnimationState();
    }
}
