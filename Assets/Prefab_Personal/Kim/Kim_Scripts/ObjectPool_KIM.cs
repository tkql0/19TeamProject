using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_KIM : MonoBehaviour
{
    [System.Serializable]
    public class Pool   //// ?�브?�트 ?� ?�이?��? ?�의???�이??모음 ?�의
    {
        public string tag;           // ?�브?�트 ?�름
        public GameObject prefab;    // ?�브?�트가 ?�떤 ?�리?�을 ?�성??것인지
        public int size;             // 몇개�??�성??것인지
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDistionary;

    private void Awake()
    {
        // ?�스?�터창의 Pools�?바탕?�로 ?�브?�트?�??만들 �? 
        // ?�브?�트?�?� ?�브?�트마다 ?�로?�며, pool개수�??�어가�?강제�??�고 ?�로???�브?�트?�게 ?�당.
        poolDistionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            // ?�는 FIFO(First-in First-out) 구조로서, 줄을 ?�는 것처??가???�래 �???enqueue) 객체가 가??먼�? 빠져 ?�올(dequeue) ???�는 구조
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake?�는 ?�간 ?�브?�트?�???�어�?Instantitate ?�어?�기 ?�문???�무?�없???�이�?조심
                GameObject obj = Instantiate(pool.prefab, transform);  //?�리?�을 Instantiate?�여 ?�브?�트�??�제�??�성?�니??
                obj.SetActive(false);       //처음 ?�성???�브?�트??비활?�화 ?�태�??�니?? ?�중???�요?????�성?�하???�용?�니??
                objectPool.Enqueue(obj);    // 줄의 가??마�?막에 ?��?.
            }
            // ?�근???�한 Dictionary???�록
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
        // 비활?�화???�브?�트�?찾기 ?�해 ?��? ?�회
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObj = objectPool.Dequeue(); // ?�에???�브?�트�?꺼냄

            if (!outObj.activeInHierarchy) // 비활?�화???�브?�트�?찾음
            {
                outObj.SetActive(true); // 비활?�화???�브?�트�??�성??
                objectPool.Enqueue(outObj); // ?�성?�된 ?�브?�트�??�시 ?�에 추�?
                return outObj; // ?�성?�된 ?�브?�트 반환
            }

            count++;
            objectPool.Enqueue(outObj); // ?�성?�된 ?�브?�트???�시 ?�에 추�?
        }

        if (count == objectPool.Count)
        {
            // 모든 ?�브?�트가 ?�성?�된 경우, ?�로???�브?�트 ?�성
            GameObject outNewObj = Instantiate(objectPool.Peek()); // ?�로??벽돌 ?�리???�성
            outNewObj.SetActive(true);
            objectPool.Enqueue(outNewObj); // ???�브?�트�??�에 추�?

            return outNewObj; // ?�로 ?�성???�브?�트 반환
        }

        return null;
    }
}
