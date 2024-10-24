using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool   //// ?ค๋ธ?ํธ ? ?ฐ์ด?ฐ๋? ?์???ฐ์ด??๋ชจ์ ?์
    {
        public string tag;           // ?ค๋ธ?ํธ ?ด๋ฆ
        public GameObject prefab;    // ?ค๋ธ?ํธ๊ฐ ?ด๋ค ?๋ฆฌ?น์ ?์ฑ??๊ฒ์ธ์ง
        public int size;             // ๋ช๊ฐ๋ฅ??์ฑ??๊ฒ์ธ์ง
    }
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDistionary;

    private void Awake()
    {
        // ?ธ์ค?ํฐ์ฐฝ์ Pools๋ฅ?๋ฐํ?ผ๋ก ?ค๋ธ?ํธ???๋ง๋ค ๊ฒ? 
        // ?ค๋ธ?ํธ?? ?ค๋ธ?ํธ๋ง๋ค ?ฐ๋ก?ด๋ฉฐ, pool๊ฐ์๋ฅ??์ด๊ฐ๋ฉ?๊ฐ์ ๋ก??๊ณ  ?๋ก???ค๋ธ?ํธ?๊ฒ ? ๋น.
        poolDistionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            // ?๋ FIFO(First-in First-out) ๊ตฌ์กฐ๋ก์, ์ค์ ?๋ ๊ฒ์ฒ??๊ฐ???ค๋ ์ค???enqueue) ๊ฐ์ฒด๊ฐ ๊ฐ??๋จผ์? ๋น ์ ธ ?์ฌ(dequeue) ???๋ ๊ตฌ์กฐ
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake?๋ ?๊ฐ ?ค๋ธ?ํธ????ค์ด๊ฐ?Instantitate ?ผ์ด?๊ธฐ ?๋ฌธ???ฐ๋ฌด?์???ฌ์ด์ฆ?์กฐ์ฌ
                GameObject obj = Instantiate(pool.prefab);  //?๋ฆฌ?น์ Instantiate?์ฌ ?ค๋ธ?ํธ๋ฅ??ค์ ๋ก??์ฑ?ฉ๋??
                obj.SetActive(false);       //์ฒ์ ?์ฑ???ค๋ธ?ํธ??๋นํ?ฑํ ?ํ๋ก??ก๋?? ?์ค???์?????์ฑ?ํ???ฌ์ฉ?ฉ๋??
                objectPool.Enqueue(obj);    // ์ค์ ๊ฐ??๋ง์?๋ง์ ?ธ์?.
            }
            // ?๊ทผ???ธํ Dictionary???ฑ๋ก
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
        // ๋นํ?ฑํ???ค๋ธ?ํธ๋ฅ?์ฐพ๊ธฐ ?ํด ?๋? ?ํ
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObj = objectPool.Dequeue(); // ?์???ค๋ธ?ํธ๋ฅ?๊บผ๋

            if (!outObj.activeInHierarchy) // ๋นํ?ฑํ???ค๋ธ?ํธ๋ฅ?์ฐพ์
            {
                outObj.SetActive(true); // ๋นํ?ฑํ???ค๋ธ?ํธ๋ฅ??์ฑ??
                objectPool.Enqueue(outObj); // ?์ฑ?๋ ?ค๋ธ?ํธ๋ฅ??ค์ ?์ ์ถ๊?
                return outObj; // ?์ฑ?๋ ?ค๋ธ?ํธ ๋ฐํ
            }

            count++;
            objectPool.Enqueue(outObj); // ?์ฑ?๋ ?ค๋ธ?ํธ???ค์ ?์ ์ถ๊?
        }

        if (count == objectPool.Count)
        {
            // ๋ชจ๋  ?ค๋ธ?ํธ๊ฐ ?์ฑ?๋ ๊ฒฝ์ฐ, ?๋ก???ค๋ธ?ํธ ?์ฑ
            GameObject outNewObj = Instantiate(objectPool.Peek()); // ?๋ก??๋ฒฝ๋ ?๋ฆฌ???์ฑ
            outNewObj.SetActive(true);
            objectPool.Enqueue(outNewObj); // ???ค๋ธ?ํธ๋ฅ??์ ์ถ๊?

            return outNewObj; // ?๋ก ?์ฑ???ค๋ธ?ํธ ๋ฐํ
        }

        return null;
    }
}
