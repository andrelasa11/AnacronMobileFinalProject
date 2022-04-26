using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelName;
   
    public void PlayGame()
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadGame()
    {        

    }       

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
