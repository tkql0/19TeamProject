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
        // 게임 레벨이 있는 스크립트에서 받아오기
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
            { // 특수 레벨일 경우 데미지 감소 없음
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
                        // 콜라이더가 사라지고 공이 통과는 것을 확인
                        //boxCollider.enabled = false;
                        // 애니메이션이 있는 오브젝트를 생성하면 되나?
                        //anim.isDie.SetBool(true);
                        //Invoke("Dead", 2f);
                        ItemSpawn();
                    }
                }
            }
        }
    }

    // �׷��� ����� �ٴڿ� ����� ��Ȳ�� �־���
    private void OnTriggerEnter2D(Collider2D incollision)
    { // ������ �ٴڿ� ��Ҵ°�?
        GameManager.Instance.GameOver();
    }
}

