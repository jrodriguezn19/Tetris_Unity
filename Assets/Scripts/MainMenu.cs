using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("GameScene2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
