using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
        
    [Header("Configuration")]
    [SerializeField] private float speedMin;
    [SerializeField] private float speedMax;

    //private:
        
    private float speed;
    private Rigidbody2D rigidBodyReference;


    void Start()
    {
        speed = Random.Range(speedMin, speedMax);

        rigidBodyReference = GetComponent<Rigidbody2D>();

        rigidBodyReference.velocity = (Vector2.down * speed);
    }


}