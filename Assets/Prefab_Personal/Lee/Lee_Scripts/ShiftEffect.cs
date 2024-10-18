using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftEffect : MonoBehaviour
{
    public Vector3 boardToward = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
        boardToward = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, boardToward, 2000 * Time.deltaTime);

    }
}
