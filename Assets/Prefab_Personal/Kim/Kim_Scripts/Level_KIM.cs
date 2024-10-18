using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_KIM : MonoBehaviour
{
    public int level;

    public void OpenScene()
    {
        SceneManager.LoadScene("MainScene " + level.ToString());
    }
}
