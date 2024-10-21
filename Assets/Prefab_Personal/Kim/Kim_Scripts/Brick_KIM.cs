using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_KIM : MonoBehaviour
{
    public int heart = 1;
    public int score = 5;

    //private Animator anim;
    //private BoxCollider2D boxCollider;

    private ItemManager itemManager;

    public int itemCount = 0;

    public float speed = 0.1f;

    public bool isSpecialLevel_Test;

    private void Awake()
    {
        //anim = GetCompoment<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
        itemManager = GetComponent<ItemManager>();
    }

    private void OnEnable()
    {
        //boxCollider.enabled = true;
        //anim.isDie.SetBool(false);
        // 게임 ?�벨???�는 ?�크립트?�서 받아?�기
        isSpecialLevel_Test = true;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    { // ���ݾ� ������ �������� �ϱ�
        transform.position = Vector2.MoveTowards(transform.position
            , transform.position + new Vector3(0, -1), 0.1f * Time.deltaTime);
    }

    public void ItemSpawn()
    {
        int randomDrop = Random.Range(0, 3);

        if (randomDrop == 2)
        {
            //int randomItem = Random.Range(0, ������ ����);
            //������.������ ����(randomItem);
            itemManager.SpawnRandomItem(transform.position);
            itemCount++;
        }

        GameManager.Instance.currentScore += score;
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (inCollision.gameObject.TryGetComponent<Ball>(out var outBall))
        {
            if (isSpecialLevel_Test)
            { // ?�수 ?�벨??경우 ?��?지 감소 ?�음
                ItemSpawn();
                return;
            }
            else
            {
                if (heart > 0)
                {
                    heart -= outBall.damage;

                    if (heart == 0)
                    {
                        // 콜라?�더가 ?�라지�?공이 ?�과??것을 ?�인
                        //boxCollider.enabled = false;
                        // ?�니메이?�이 ?�는 ?�브?�트�??�성?�면 ?�나?
                        //anim.isDie.SetBool(true);
                        //Invoke("Dead", 2f);
                        ItemSpawn();
                    }
                }
            }
        }
    }

    // �׷��� �����?�ٴڿ� �����?��Ȳ�� �־���
    private void OnTriggerEnter2D(Collider2D incollision)
    { // ������ �ٴڿ� ��Ҵ°�?
        GameManager.Instance.GameOver(true);
    }
}

