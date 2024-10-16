using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{


    private void Update()
    { // Board�� ��ĥ �� �ֱ� ������ ��Ÿ���� ����

    }

    private void OnTriggerEnter2D(Collider2D collision)
    { // ���� ��Ͽ� ��Ҵ°�
        if(collision.TryGetComponent<Ball>(out var outBall))
        { // �Ʒ��� ��� ������
            outBall.rigid2D.AddForce(Vector2.down * outBall.speed, ForceMode2D.Impulse);
        }
        else
        { // ���� ���� ���� �ƴ� �ٸ� ���̶��
            gameObject.SetActive(false);
        }
    }
}
