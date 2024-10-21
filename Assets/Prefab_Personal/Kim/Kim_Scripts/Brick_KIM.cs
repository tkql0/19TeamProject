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
        // ���� ������ �ִ� ��ũ��Ʈ���� �޾ƿ���
        isSpecialLevel_Test = false;
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

    public void Dead()
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
            { // Ư�� ������ ��� ������ ���� ����
                int randomDrop = Random.Range(0, 3);

                if(randomDrop == 2)
                {
                    //int randomItem = Random.Range(0, ������ ����);

                    //������.������ ����(randomItem);
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
                // �ݶ��̴��� ������� ���� ����� ���� Ȯ��
                boxCollider.enabled = false;
                // �ִϸ��̼��� �ִ� ������Ʈ�� �����ϸ� �ǳ�?
                //anim.isDie.SetBool(true);
                Invoke("Dead", 2f);
                return;
            }
        }
    }

    // �׷��� ����� �ٴڿ� ����� ��Ȳ�� �־���
    private void OnTriggerEnter2D(Collider2D incollision)
    { // ������ �ٴڿ� ��Ҵ°�?
        GameManager.Instance.GameOver();
    }
}

