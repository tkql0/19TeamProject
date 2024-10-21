using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemSO> items = new List<ItemSO>();

    public void SpawnRandomItem(Vector2 inSpawnPosition)
    {
        if (items.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, items.Count);
        ItemSO selectedItem = items[3];

        CreateItem(selectedItem, inSpawnPosition);
    }

    private void CreateItem(ItemSO inItem, Vector2 inSpawnPosition)
    {
        GameObject itemObject;
        if (inItem.itemType == ItemType.Ball)
        {
            itemObject = new GameObject(inItem.ballType.ToString());
        }
        else// if (inItem.itemType == ItemType.Paddle)
        {
            itemObject = new GameObject(inItem.paddleType.ToString());
        }
        
        SpriteRenderer renderer = itemObject.AddComponent<SpriteRenderer>();
        Rigidbody2D rigidbody = itemObject.AddComponent<Rigidbody2D>();
        CircleCollider2D collider =itemObject.AddComponent<CircleCollider2D>();
        ItemSOHolder itemSOHolder = itemObject.AddComponent<ItemSOHolder>();
        ItemBehavior behavior = itemObject.AddComponent<ItemBehavior>();

        itemObject.layer = inItem.SetLayer;
        itemObject.transform.position = inSpawnPosition;
        renderer.sprite = inItem.itemSprite;
        rigidbody.gravityScale = 0;
        collider.isTrigger = true;
        itemSOHolder.itemSO = inItem;
    }
}
