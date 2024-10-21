using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLevel_Board : MonoBehaviour
{
    public ObjectPool_KIM pool;

    public GameObject Brick;

    public float brickSpawnTime;
    public float maxSpawnTime;

    private int spawnCount = 0;

    private void Awake()
    {
        pool = GetComponent<ObjectPool_KIM>();
    }

    private void Start()
    { // ���̵� ��ư�� ������ ���� �Ѿ�� �� �����?�ʱ� ���� ����
        // ����ü���̱� ������ �ٸ� ���̵� ó�� ó������ ���� ������
        // �ݹ� ������ ������ ������ ���� �� �پ�
        Spawn();
        brickSpawnTime = 0;
        maxSpawnTime = 20f;
        spawnCount = 1;
    }

    private void Update()
    { // �ð� ����
        brickSpawnTime += Time.deltaTime;

        if (maxSpawnTime <= brickSpawnTime)
        { // 30��? ���� ���ϵ��� �������� brickSpawnTime �ʱ�ȭ
            brickSpawnTime = 0;

            Spawn();
        }
    }

    private void Spawn()
    {// ������ �� �� ������Ʈ�� �����ϰ� �� ��ġ���� �������� �����ұ�?
        if (spawnCount % 2 == 0)
        {
            SpawnPosition(3.4f, 7.6f);
        }
        else
        {
            SpawnPosition(-3.4f, -7.6f);
        }

        spawnCount++;
        // ���� ���� ��ġ�� ������ - ������׷�?������
    }

    private void SpawnPosition(float inSpawnNumber, float inSpawnDirection)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject newBrick = pool.SpawnFromPool("Brick");
            float x = i % 10 * inSpawnNumber - inSpawnDirection;

            newBrick.transform.position = new Vector2(x, 4f);
        }
    }
}
