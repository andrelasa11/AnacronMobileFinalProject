using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;

    public void DestroyThis()
    {
        Destroy(gameObject, destroyTime);
    }
}
