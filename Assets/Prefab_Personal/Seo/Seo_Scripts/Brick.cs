using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ball;

    public GameObject bar;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();
        bar = GetComponent<GameObject>();
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (inCollision.gameObject.layer == 7)
        {
            this.gameObject.SetActive(false);
        }
        else if (inCollision.gameObject == bar)
        {
            //게임 ??
        }
    }
}
