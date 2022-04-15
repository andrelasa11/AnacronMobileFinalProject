using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMultipleObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    public void DestroyAll()
    {
        if(objects != null)
        {
            foreach (var obj in objects)
            {
                Destroy(obj);
            }
        }
        
    }
}
