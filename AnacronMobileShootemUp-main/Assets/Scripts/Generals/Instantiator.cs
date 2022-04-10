using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject prefab;

    public void DoInstantiate()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
