using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_KIM : MonoBehaviour
{
    public int heart;
    public int score = 5;

    //private Animator anim;
    private BoxCollider2D boxCollider;

    private ItemManager itemManager;

    public int itemCount = 0;

    public float speed = 0.1f;

    public bool isSpecialLevel_Test;

    private void Awake()
    {
        //anim = GetCompoment<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        itemManager = GetComponent<ItemManager>();
    }

    private void OnEnable()
    {
        boxCollider.enabled = true;
        //anim.isDie.SetBool(false);
        heart = 1;
        // 게임 레벨이 있는 스크립트에서 받아오기
        isSpecialLevel_Test = false;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    { // 조금씩 벽돌이 내려오게 하기
        transform.position = Vector2.MoveTowards(transform.position
            , transform.position + new Vector3(0, -1), 0.1f * Time.deltaTime);
    }

    public void Dead()
    {
        int randomDrop = Random.Range(0, 3);

        if (randomDrop == 2)
        {
            //int randomItem = Random.Range(0, 아이템 종류);
            //아이템.아이템 생성(randomItem);
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
            { // 특수 레벨일 경우 데미지 감소 없음
                int randomDrop = Random.Range(0, 3);

                if(randomDrop == 2)
                {
                    //int randomItem = Random.Range(0, 아이템 종류);

                    //아이템.아이템 생성(randomItem);
                    itemManager.SpawnRandomItem(transform.position);
                    GameManager.Instance.currentScore += score;
                }

                return;
            }

            if (heart > 0)
            {
                heart -= outBall.damage;
            }
            else
            {
                // 콜라이더가 사라지고 공이 통과는 것을 확인
                boxCollider.enabled = false;
                // 애니메이션이 있는 오브젝트를 생성하면 되나?
                //anim.isDie.SetBool(true);
                Invoke("Dead", 2f);
                return;
            }
        }
    }

    // 그러네 블록이 바닥에 닿았을 상황도 있었지
    private void OnTriggerEnter2D(Collider2D incollision)
    { // 벽돌이 바닥에 닿았는가?
        GameManager.Instance.GameOver();
    }
}

