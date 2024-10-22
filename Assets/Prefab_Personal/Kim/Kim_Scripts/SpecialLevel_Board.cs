using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLevel_Board : MonoBehaviour
{
    private ObjectPool pool;

    private float brickSpawnTime;
    private float maxbrickSpawnTime;

    private int spawnCount;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        Spawn();
        brickSpawnTime = 0;
        maxbrickSpawnTime = 20f;
        spawnCount = 1;
    }

    private void Update()
    {
        brickSpawnTime += Time.deltaTime;

        if (maxbrickSpawnTime <= brickSpawnTime)
        {
            brickSpawnTime = 0;

            Spawn();
        }
    }

    private void Spawn()
    {
        if (spawnCount % 2 == 0)
        {
            SpawnPosition(3.4f, 7.6f);
        }
        else
        {
            SpawnPosition(-3.4f, -7.6f);
        }

        spawnCount++;
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
