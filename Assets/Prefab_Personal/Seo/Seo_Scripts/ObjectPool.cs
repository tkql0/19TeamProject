using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool   //// 오브젝트 풀 데이터를 정의할 데이터 모음 정의
    {
        public string tag;           // 오브젝트 이름
        public GameObject prefab;    // 오브젝트가 어떤 프리팹을 생성할 것인지
        public int size;             // 몇개를 생성할 것인지
    }
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDistionary;

    private void Awake()
    {
        // 인스펙터창의 Pools를 바탕으로 오브젝트풀을 만들 것. 
        // 오브젝트풀은 오브젝트마다 따로이며, pool개수를 넘어가면 강제로 끄고 새로운 오브젝트에게 할당.
        poolDistionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            // 큐는 FIFO(First-in First-out) 구조로서, 줄을 서는 것처럼 가장 오래 줄 선(enqueue) 객체가 가장 먼저 빠져 나올(dequeue) 수 있는 구조
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake하는 순간 오브젝트풀에 들어갈 Instantitate 일어나기 때문에 터무니없는 사이즈 조심
                GameObject obj = Instantiate(pool.prefab);  //프리팹을 Instantiate하여 오브젝트를 실제로 생성합니다.
                obj.SetActive(false);       //처음 생성된 오브젝트는 비활성화 상태로 둡니다. 나중에 필요할 때 활성화하여 사용합니다.
                objectPool.Enqueue(obj);    // 줄의 가장 마지막에 세움.
            }
            // 접근이 편한 Dictionary에 등록
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
        // 비활성화된 오브젝트를 찾기 위해 큐를 순회
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObj = objectPool.Dequeue(); // 큐에서 오브젝트를 꺼냄

            if (!outObj.activeInHierarchy) // 비활성화된 오브젝트를 찾음
            {
                outObj.SetActive(true); // 비활성화된 오브젝트를 활성화
                objectPool.Enqueue(outObj); // 활성화된 오브젝트를 다시 큐에 추가
                return outObj; // 활성화된 오브젝트 반환
            }

            count++;
            objectPool.Enqueue(outObj); // 활성화된 오브젝트는 다시 큐에 추가
        }

        if (count == objectPool.Count)
        {
            // 모든 오브젝트가 활성화된 경우, 새로운 오브젝트 생성
            GameObject outNewObj = Instantiate(objectPool.Peek()); // 새로운 벽돌 프리팹 생성
            outNewObj.SetActive(true);
            objectPool.Enqueue(outNewObj); // 새 오브젝트를 큐에 추가

            return outNewObj; // 새로 생성된 오브젝트 반환
        }

        return null;
    }
}
