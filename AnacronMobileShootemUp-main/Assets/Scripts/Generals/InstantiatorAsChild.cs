using UnityEngine;

public class InstantiatorAsChild : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject prefab;

    public void DoInstantiate()
    {
        Instantiate(prefab, transform, transform);
    }
}
