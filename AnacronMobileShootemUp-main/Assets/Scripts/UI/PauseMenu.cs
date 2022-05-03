using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject stickUI;


    public void DoPauseOrResume()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        if(pauseMenuUI != null && stickUI != null)
        {
            pauseMenuUI.SetActive(false);
            stickUI.SetActive(true);
        }        
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null && stickUI != null)
        {
            pauseMenuUI.SetActive(true);
            stickUI.SetActive(false);
        }
       
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {        
        Application.Quit();
    }
}
