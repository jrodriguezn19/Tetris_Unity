using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    //Load Level 1
    public void PlayLevel1()
    {
        SceneManager.LoadScene("GameScene1");
    }
    //Load Level 2
    public void PlayLevel2()
    {
        SceneManager.LoadScene("GameScene2");
    }
    //Quit the Game
    public void Quit()
    {
        Application.Quit();
    }
}
