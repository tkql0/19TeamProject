using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallItemEffect : MonoBehaviour
{
    public void BallScaleUp()
    {
        for (int i = 0; i < GameManager.Instance.BallList.Count; i++)
        { // ������ ������ �޾ƿ��� �� �� �𸣰���
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

    public void BallIncrease()
    {
        int spawnCount = GameManager.Instance.BallList.Count;
        // ���� ������Ʈ���� �߰� �ߴ��� ���� �� ���߿� �˾ƺ� ����

        for (int i = 0; i < spawnCount; i++)
        {
            GameManager.Instance.BallList[i].TryGetComponent<Ball>(out var outBall);

            GameManager.Instance.BallList.Add(Instantiate(GameManager.Instance.Ball,
            outBall.transform.position, Quaternion.identity));
        }
    }

    public void BlockPenetration()
    { // �̰� ��� �ʿ���  isTrigger�� ��Ȱ��ȭ �������
        // ���� ������ �ٲٰ� ���ӸŴ����� ���� ���¶�� bool�� ������ָ�
        // ��� �ʿ��� �ش� bool�� �Ǵ��ϰ� isTrigger�� ��Ȱ��ȭ���ִ� �ڵ�?
        // �ڷ�ƾ���� �ð� ����
    }
}
