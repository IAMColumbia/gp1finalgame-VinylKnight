using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField]
    private string mainMenuLevel;
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuLevel);
    }
    public void RestartGame()
    {
        FindObjectOfType<GameplayManager>().Reset();
    }
}
