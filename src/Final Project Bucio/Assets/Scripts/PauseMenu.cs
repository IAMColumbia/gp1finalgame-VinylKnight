using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private string mainMenuLevel;
    [SerializeField]
    private GameObject pauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(mainMenuLevel);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameplayManager>().Reset();
    }
}
