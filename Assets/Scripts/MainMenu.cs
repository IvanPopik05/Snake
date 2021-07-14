using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string GameScene;
    public void Play() 
    {
        sceneFader.FadeTo(GameScene);
    }
    public void Quit() 
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
