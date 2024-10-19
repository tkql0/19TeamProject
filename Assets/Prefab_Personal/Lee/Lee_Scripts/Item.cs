//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Item : MonoBehaviour
//{
//    public enum ItemType
//    {
//        BallNumber,
//        BallPower,
//        PaddleIncrease
//    }
//    Rigidbody2D _rb2d;
//    public ItemType itemType = ItemType.BallNumber;
//    SpriteRenderer spriteRenderer;
//    [SerializeField] Sprite ballNumber;
//    [SerializeField] Sprite ballPower;
//    [SerializeField] Sprite paddleIncrease;

//    private void Awake()
//    {
//        _rb2d = GetComponent<Rigidbody2D>();
//        spriteRenderer = GetComponent<SpriteRenderer>();

//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        switch (itemType)
//        {
//            case ItemType.BallNumber:
//                spriteRenderer.sprite = ballNumber;
//                break;
//            case ItemType.BallPower:
//                spriteRenderer.sprite = ballPower;
//                break;
//            case ItemType.PaddleIncrease:
//                spriteRenderer.sprite = paddleIncrease;
//                break;
//        }

//        _rb2d.velocity = Vector2.down;
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            switch (itemType)
//            {
//                case ItemType.BallNumber:
//                    GameManager.Instance.BallNumber();
//                    break;
//                case ItemType.BallPower:
//                    GameManager.Instance.BallPower();
//                    break;
//                case ItemType.PaddleIncrease:
//                    GameManager.Instance.PaddleIncrease();
//                    break;
//            }


//            Destroy(gameObject);
//        }

//    }

//}
