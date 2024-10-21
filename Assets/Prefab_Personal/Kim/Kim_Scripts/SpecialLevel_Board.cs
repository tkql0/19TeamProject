using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLevel : MonoBehaviour
{
    //public ObjectPool_KIM pool;

    public GameObject Brick;

    public float brickSpawnTime;
    public float maxSpawnTime;

    private int spawnCount = 0;

    private void Awake()
    {
        //pool = GetComponent<ObjectPool_KIM>();
    }

    private void Start()
    { // 난이도 버튼이 눌리고 씬이 넘어갔을 때 생기는 초기 블록 셋팅
        // 무한체력이기 때문에 다른 난이도 처럼 처음부터 많이 나오면
        // 금방 끝나기 때문에 위에서 부터 한 줄씩
        Spawn();
        brickSpawnTime = 0;
        maxSpawnTime = 20f;
        spawnCount = 1;
    }

    private void Update()
    { // 시간 증가
        brickSpawnTime += Time.deltaTime;

        if (maxSpawnTime <= brickSpawnTime)
        { // 30초? 마다 블록들이 내려오고 brickSpawnTime 초기화
            brickSpawnTime = 0;

            Spawn();
        }
    }

    private void Spawn()
    {// 시작할 때 빈 오브젝트를 생성하고 그 위치에서 랜덤으로 생성할까?
        if (spawnCount % 2 == 0)
        {
            SpawnPosition(3.4f, 7.6f);
        }
        else
        {
            SpawnPosition(-3.4f, -7.6f);
        }

        spawnCount++;
        // 현재 같은 위치에 생성됨 - 지그재그로 생성됨
    }

    private void SpawnPosition(float inSpawnNumber, float inSpawnDirection)
    {
        for (int i = 0; i < 5; i++)
        {
            //GameObject newBrick = GameManager.Instance.pool.SpawnFromPool("Brick");
            float x = i % 10 * inSpawnNumber - inSpawnDirection;

            //newBrick.transform.position = new Vector2(x, 4f);
        }
    }
}
