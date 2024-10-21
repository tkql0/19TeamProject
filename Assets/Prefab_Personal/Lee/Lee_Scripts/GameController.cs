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
        Instantiate(player1);
        if (GameManager.Instance.isMultiplay)
        {
            Instantiate(player2);
        }
        GameManager.Instance.StageStart();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
