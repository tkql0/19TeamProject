using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject UICanvas;
    // Start is called before the first frame update
    void Start()
    {
        List<int> scoreList = GameManager.Instance.scoreRanking;
        scoreList = new List<int> { 15, 10, 8, 7 };

        for (int i = 0; i < scoreList.Count; i++)
        {
            TMP_Text txt = Instantiate(ScoreText, UICanvas.transform.position , Quaternion.identity);
            txt.transform.position += new Vector3(0, 100 - 50 * i, 0);
            txt.transform.parent = UICanvas.transform;
            txt.text = $"{i+1}. {scoreList[i]} pt";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
