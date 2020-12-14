using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
