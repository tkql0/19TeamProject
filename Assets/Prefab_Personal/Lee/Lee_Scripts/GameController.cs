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
        GameManager.Instance.player1 = Instantiate(player1);
        if (GameManager.Instance.isMultiplay)
        {
            Instantiate(player2);
        }
        

        GameManager.Instance.player1.TryGetComponent<ItemEffectHandler>(out var player1ItemHandler);
        GameManager.Instance.Ball.TryGetComponent<BallItemEffect>(out var itemEffect);
        GameManager.Instance.Ball.TryGetComponent<BallDuplicator>(out var duplicator);
        itemEffect.effectHandler = player1ItemHandler;
        duplicator.effectHandler = player1ItemHandler;
        GameManager.Instance.StageStart();


    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.StageStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
