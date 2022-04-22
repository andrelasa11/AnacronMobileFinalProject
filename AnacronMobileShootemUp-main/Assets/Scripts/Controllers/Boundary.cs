using UnityEngine;

[System.Serializable]
public class BoundaryValue
{
    public float xMin, xMax, yMin, yMax;

    // X: -2.75 ~ 2.75
    // Y: -4.75 ~ 4.75
}

public class Boundary : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] private BoundaryValue boundaryValue;

    [Header("Dependencies")]
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            float x = Mathf.Clamp(playerTransform.position.x, boundaryValue.xMin, boundaryValue.xMax);
            float y = Mathf.Clamp(playerTransform.position.y, boundaryValue.yMin, boundaryValue.yMax);
            playerTransform.position = new Vector3(x, y, 0);
        }
        
    }
}
