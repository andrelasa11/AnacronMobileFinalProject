using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnLoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
