using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ToSelectSingle()
    {
        GameManager.Instance.isMultiplay = false;
    }

    public void ToSelectMulti()
    {
        GameManager.Instance.isMultiplay = true;
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
