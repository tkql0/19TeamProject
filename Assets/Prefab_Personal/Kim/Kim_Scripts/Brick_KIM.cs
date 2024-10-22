using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_KIM : MonoBehaviour
{
    public int heart = 1;
    public int score = 5;

    private Animator anim;
    //private BoxCollider2D boxCollider;

    private ItemManager itemManager;

    public bool isSpecialLevel_Test;

    private int itemCount;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
        itemManager = GetComponent<ItemManager>();
    }

    private void OnEnable()
    {
        //boxCollider.enabled = true;
        anim.SetBool("isMelt",false);
        itemCount = 0;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position
            , transform.position + new Vector3(0, -1), 0.1f * Time.deltaTime);
    }

    public void ItemSpawn()
    {
        int randomDrop = Random.Range(0, 3);

        if (randomDrop == 2)
        {
            itemManager.SpawnRandomItem(transform.position);
        }

        GameManager.Instance.currentScore += score;
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (!inCollision.gameObject.TryGetComponent<Ball>(out var outBall))
        {
            return;
        }

        if (isSpecialLevel_Test)
        {
            if (itemCount <= 3)
            {
                ItemSpawn();
                itemCount++;
            }
            else
            {
                StartCoroutine(ItemCoolTime());
            }
        }
        else
        {
            if (heart > 0)
            {
                heart -= outBall.damage;

                if (heart == 0)
                {
                    //boxCollider.enabled = false;
                    //anim.isDie.SetBool(true);
                    //Invoke("Dead", 2f);
                    ItemSpawn();
                }
            }
        }
    }

    IEnumerator ItemCoolTime()
    {
        anim.SetBool("isMelt", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("isMelt", false);
        itemCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D incollision)
    {
        if (incollision.gameObject.layer == 8)
        {
            GameManager.Instance.GameOver(true);
        }
    }
}

