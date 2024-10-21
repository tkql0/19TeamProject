using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanelAnimationController : MonoBehaviour
{
    Animator animator;
    
    private static readonly int isDown = Animator.StringToHash("isDown");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Down()
    {
        animator.SetBool(isDown, true);
    }
}
