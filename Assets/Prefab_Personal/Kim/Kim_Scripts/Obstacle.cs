using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{


    private void Update()
    { // Board와 겹칠 수 있기 때문에 쿨타임을 두자

    }

    private void OnTriggerEnter2D(Collider2D collision)
    { // 공이 블록에 닿았는가
        if(collision.TryGetComponent<Ball>(out var outBall))
        { // 아래로 흘려 내리기
            outBall.rigid2D.AddForce(Vector2.down * outBall.speed, ForceMode2D.Impulse);
        }
        else
        { // 닿은 것이 공이 아닌 다른 것이라면
            gameObject.SetActive(false);
        }
    }
}
