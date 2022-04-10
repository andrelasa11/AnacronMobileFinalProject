using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Configuration")]
    public float speed;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
