using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string sceneToLoad;
    [SerializeField] private Animator transition;

    public void OnLoadScene()
    {
        StartCoroutine(LoadSceneAnimation());
    }

    IEnumerator LoadSceneAnimation()
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1f);
        }        

        SceneManager.LoadScene(sceneToLoad);
    }
}
