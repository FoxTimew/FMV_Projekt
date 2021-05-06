using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_PingScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private string currentAnimation;
    const string APPARITION_ANIM = "Apparition";
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LaunchApparitionAnim()
    {
        ChangeAnimationState(APPARITION_ANIM);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        anim.Play(newAnimation);

        currentAnimation = newAnimation;
    }
}
