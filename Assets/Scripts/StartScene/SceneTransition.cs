using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadLevelOneScene ()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
