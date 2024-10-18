using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_P : MonoBehaviour
{
    public GameObject brick;
    
    private ObjectPool pool;

    private void Awake()
    {
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    void Start()
    { 
        for (int i = 0; i < 50; i++)
        {
            GameObject newBrick = pool.SpawnFromPool("Brick");
            float x = i % 10 * 1.7f - 7.6f;
            float y = i / 10 * 1;

            newBrick.transform.position = new Vector2(x, y);
        }
    }
}