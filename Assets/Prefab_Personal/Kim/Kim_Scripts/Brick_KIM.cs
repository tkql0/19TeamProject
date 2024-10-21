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
        // ê²Œì„ ?ˆë²¨???ˆëŠ” ?¤í¬ë¦½íŠ¸?ì„œ ë°›ì•„?¤ê¸°
        isSpecialLevel_Test = true;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    { // ï¿½ï¿½ï¿½İ¾ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ï±ï¿½
        transform.position = Vector2.MoveTowards(transform.position
            , transform.position + new Vector3(0, -1), 0.1f * Time.deltaTime);
    }

    public void ItemSpawn()
    {
        int randomDrop = Random.Range(0, 3);

        if (randomDrop == 2)
        {
            //int randomItem = Random.Range(0, ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½);
            //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½.ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½(randomItem);
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
            { // ?¹ìˆ˜ ?ˆë²¨??ê²½ìš° ?°ë?ì§€ ê°ì†Œ ?†ìŒ
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
                        // ì½œë¼?´ë”ê°€ ?¬ë¼ì§€ê³?ê³µì´ ?µê³¼??ê²ƒì„ ?•ì¸
                        //boxCollider.enabled = false;
                        // ? ë‹ˆë©”ì´?˜ì´ ?ˆëŠ” ?¤ë¸Œ?íŠ¸ë¥??ì„±?˜ë©´ ?˜ë‚˜?
                        //anim.isDie.SetBool(true);
                        //Invoke("Dead", 2f);
                        ItemSpawn();
                    }
                }
            }
        }
    }

    // ï¿½×·ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿?ï¿½Ù´Ú¿ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿?ï¿½ï¿½È²ï¿½ï¿½ ï¿½Ö¾ï¿½ï¿½ï¿½
    private void OnTriggerEnter2D(Collider2D incollision)
    { // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ù´Ú¿ï¿½ ï¿½ï¿½Ò´Â°ï¿?
        GameManager.Instance.GameOver(true);
    }
}

