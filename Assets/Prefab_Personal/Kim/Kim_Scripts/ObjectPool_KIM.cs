using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_KIM : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDistionary;

    private void Awake()
    {
        poolDistionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDistionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string intag)
    {
        if (!poolDistionary.ContainsKey(intag))
        {
            return null;
        }
        Queue<GameObject> objectPool = poolDistionary[intag];

        int count = objectPool.Count;
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObj = objectPool.Dequeue();

            if (!outObj.activeInHierarchy)
            {
                outObj.SetActive(true);
                objectPool.Enqueue(outObj);
                return outObj;
            }

            count++;
            objectPool.Enqueue(outObj);
        }

        if (count == objectPool.Count)
        {
            GameObject outNewObj = Instantiate(objectPool.Peek()); // ?ˆë¡œ??ë²½ëŒ ?„ë¦¬???ì„±
            outNewObj.SetActive(true);
            objectPool.Enqueue(outNewObj);

            return outNewObj;
        }

        return null;
    }
}
