using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private void Awake()
    {
        Invoke("NextScene", 1.5f);
    }
    
    private void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
