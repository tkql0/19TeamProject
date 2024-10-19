using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_KIM : MonoBehaviour
{
    [System.Serializable]
    public class Pool   //// ?¤ë¸Œ?íŠ¸ ?€ ?°ì´?°ë? ?•ì˜???°ì´??ëª¨ìŒ ?•ì˜
    {
        public string tag;           // ?¤ë¸Œ?íŠ¸ ?´ë¦„
        public GameObject prefab;    // ?¤ë¸Œ?íŠ¸ê°€ ?´ë–¤ ?„ë¦¬?¹ì„ ?ì„±??ê²ƒì¸ì§€
        public int size;             // ëª‡ê°œë¥??ì„±??ê²ƒì¸ì§€
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDistionary;

    private void Awake()
    {
        // ?¸ìŠ¤?™í„°ì°½ì˜ Poolsë¥?ë°”íƒ•?¼ë¡œ ?¤ë¸Œ?íŠ¸?€??ë§Œë“¤ ê²? 
        // ?¤ë¸Œ?íŠ¸?€?€ ?¤ë¸Œ?íŠ¸ë§ˆë‹¤ ?°ë¡œ?´ë©°, poolê°œìˆ˜ë¥??˜ì–´ê°€ë©?ê°•ì œë¡??„ê³  ?ˆë¡œ???¤ë¸Œ?íŠ¸?ê²Œ ? ë‹¹.
        poolDistionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            // ?ëŠ” FIFO(First-in First-out) êµ¬ì¡°ë¡œì„œ, ì¤„ì„ ?œëŠ” ê²ƒì²˜??ê°€???¤ë˜ ì¤???enqueue) ê°ì²´ê°€ ê°€??ë¨¼ì? ë¹ ì ¸ ?˜ì˜¬(dequeue) ???ˆëŠ” êµ¬ì¡°
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake?˜ëŠ” ?œê°„ ?¤ë¸Œ?íŠ¸?€???¤ì–´ê°?Instantitate ?¼ì–´?˜ê¸° ?Œë¬¸???°ë¬´?ˆì—†???¬ì´ì¦?ì¡°ì‹¬
                GameObject obj = Instantiate(pool.prefab, transform);  //?„ë¦¬?¹ì„ Instantiate?˜ì—¬ ?¤ë¸Œ?íŠ¸ë¥??¤ì œë¡??ì„±?©ë‹ˆ??
                obj.SetActive(false);       //ì²˜ìŒ ?ì„±???¤ë¸Œ?íŠ¸??ë¹„í™œ?±í™” ?íƒœë¡??¡ë‹ˆ?? ?˜ì¤‘???„ìš”?????œì„±?”í•˜???¬ìš©?©ë‹ˆ??
                objectPool.Enqueue(obj);    // ì¤„ì˜ ê°€??ë§ˆì?ë§‰ì— ?¸ì?.
            }
            // ?‘ê·¼???¸í•œ Dictionary???±ë¡
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
        // ë¹„í™œ?±í™”???¤ë¸Œ?íŠ¸ë¥?ì°¾ê¸° ?„í•´ ?ë? ?œíšŒ
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObj = objectPool.Dequeue(); // ?ì—???¤ë¸Œ?íŠ¸ë¥?êº¼ëƒ„

            if (!outObj.activeInHierarchy) // ë¹„í™œ?±í™”???¤ë¸Œ?íŠ¸ë¥?ì°¾ìŒ
            {
                outObj.SetActive(true); // ë¹„í™œ?±í™”???¤ë¸Œ?íŠ¸ë¥??œì„±??
                objectPool.Enqueue(outObj); // ?œì„±?”ëœ ?¤ë¸Œ?íŠ¸ë¥??¤ì‹œ ?ì— ì¶”ê?
                return outObj; // ?œì„±?”ëœ ?¤ë¸Œ?íŠ¸ ë°˜í™˜
            }

            count++;
            objectPool.Enqueue(outObj); // ?œì„±?”ëœ ?¤ë¸Œ?íŠ¸???¤ì‹œ ?ì— ì¶”ê?
        }

        if (count == objectPool.Count)
        {
            // ëª¨ë“  ?¤ë¸Œ?íŠ¸ê°€ ?œì„±?”ëœ ê²½ìš°, ?ˆë¡œ???¤ë¸Œ?íŠ¸ ?ì„±
            GameObject outNewObj = Instantiate(objectPool.Peek()); // ?ˆë¡œ??ë²½ëŒ ?„ë¦¬???ì„±
            outNewObj.SetActive(true);
            objectPool.Enqueue(outNewObj); // ???¤ë¸Œ?íŠ¸ë¥??ì— ì¶”ê?

            return outNewObj; // ?ˆë¡œ ?ì„±???¤ë¸Œ?íŠ¸ ë°˜í™˜
        }

        return null;
    }
}
