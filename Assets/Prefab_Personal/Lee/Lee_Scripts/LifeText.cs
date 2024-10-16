using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeText : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.Instance.life.ToString();
    }
}
