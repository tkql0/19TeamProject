using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallItemEffect : MonoBehaviour
{
    public void BallScaleUp()
    {
        for (int i = 0; i < GameManager.Instance.BallList.Count; i++)
        { // 아이템 정보값 받아오는 법 잘 모르겠음
            //GameManager.Instance.BallList[i].transform.localScale.x
            //GameManager.Instance.BallList[i].transform.localScale.y
        }
    }

    public void BallScaleDown()
    {
        for (int i = 0; i < GameManager.Instance.BallList.Count; i++)
        {
            //GameManager.Instance.BallList[i].transform.localScale.x
            //GameManager.Instance.BallList[i].transform.localScale.y
        }
    }

    public void BallCopy()
    {
        int spawnCount = GameManager.Instance.BallList.Count;
        // 공을 오브젝트폴에 추가 했더니 오류 뜸 나중에 알아볼 예정 - 해결

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newBall = GameManager.Instance.pool.SpawnFromPool("Ball");
            newBall.transform.position = GameManager.Instance.BallList[i].transform.position;
            GameManager.Instance.BallList.Add(newBall);
        }
    }

    public void BlockPenetration()
    { // 이건 블록 쪽에서  isTrigger을 비활성화 해줘야함
        // 공을 빨갛게 바꾸고 게임매니저에 관통 상태라는 bool을 만들어주면
        // 블록 쪽에서 해당 bool을 판단하고 isTrigger을 비활성화해주는 코드?
        // 코루틴으로 시간 제한
    }
}
