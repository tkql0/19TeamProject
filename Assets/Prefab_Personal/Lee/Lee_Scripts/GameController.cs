using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private void Awake()
    {
        GameObject player1Instance = Instantiate(player1);
        player1Instance.TryGetComponent<ItemEffectHandler>(out var player1ItemHandler);
        GameManager.Instance.Ball.TryGetComponent<BallItemEffect>(out var itemEffect);
        itemEffect.effectHandler.Clear();
        itemEffect.effectHandler.Add(player1ItemHandler);
        GameObject player2Instance = null;
        if (GameManager.Instance.isMultiplay)
        {
            player2Instance = Instantiate(player2);
            player2Instance.TryGetComponent<ItemEffectHandler>(out var player2ItemHandler);
            itemEffect.effectHandler.Add(player2ItemHandler);
        }
        GameManager.Instance.StageStart();
    }
}
