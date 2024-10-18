using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenScene()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("MainScene"); // Load the base scene
        }
        else
        {
            SceneManager.LoadScene("MainScene " + level.ToString()); // Load numbered scenes (with space)
        }

    }
}
