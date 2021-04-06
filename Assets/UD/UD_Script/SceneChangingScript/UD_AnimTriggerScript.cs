using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_AnimTriggerScript : MonoBehaviour
{
    private string currentAnimation;
    [HideInInspector] public string animationName;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimationState()
    {
        if (currentAnimation == animationName) return;

        anim.Play(animationName);
    }
}
