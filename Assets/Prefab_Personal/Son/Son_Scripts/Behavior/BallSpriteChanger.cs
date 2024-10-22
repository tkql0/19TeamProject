using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] ballSprite;
    [SerializeField] private Animation anim;
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
        anim = GetComponent<Animation>();
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
                break;
            case 2:
                ballSpriteRenderer.sprite = ballSprite[2];
                break;
            case 3:
                Debug.Log("애니메이션");
                capsulCollider.enabled = false;
                Vector3 stopPosition = transform.position;
                transform.position = stopPosition;
                //rigidbody2D.isKinematic = true;
                Destroy(gameObject,0.5f);
                //anim.SetBool("isBoom", true);
                //if (!isBoom)
                //{
                //}
                break;
        }
    }
}
