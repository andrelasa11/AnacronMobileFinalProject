using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator transition;
   
    public void PlayGame()
    {
        if(gameManager != null)
        {
            gameManager.ResetValue();
        }
        
        StartCoroutine(NewGameAnimation());
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    IEnumerator NewGameAnimation()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelName);
    }
}
