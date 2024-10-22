using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] ballSprite;
    [SerializeField] private Animator anim;
    private BallStats stats;
    private SpriteRenderer ballSpriteRenderer;
    private CapsuleCollider2D capsulCollider;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        stats = GetComponent<BallStats>();
        ballSpriteRenderer = GetComponent<SpriteRenderer>();
        capsulCollider = GetComponent<CapsuleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        stats.ONBallSpriteChanger += OnSpriteChange;
    }

    private void OnDisable()
    {
        stats.ONBallSpriteChanger -= OnSpriteChange;
    }

    private void OnSpriteChange(int inDoubleItemCount)
    {
        switch (inDoubleItemCount)
        {
            case 1:
                ballSpriteRenderer.sprite = ballSprite[1];
                anim.SetBool("isChangeOrange", true);
                break;
            case 2:
                ballSpriteRenderer.sprite = ballSprite[2];
                anim.SetBool("isChangeRed", true);
                break;
            case 3:
                Debug.Log("애니메이션");
                capsulCollider.enabled = false;
                rigidbody2D.velocity = Vector3.zero;
                anim.SetBool("isBoom", true);
                Destroy(gameObject,0.5f);
                break;
        }
    }
}
