using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneYellowMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private Transform finalTarget;

    // Start is called before the first frame update
    void Start()
    {
        target.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
