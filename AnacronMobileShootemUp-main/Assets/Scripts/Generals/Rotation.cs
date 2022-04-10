using UnityEngine;

public class Rotation : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] private float rotateMin;
    [SerializeField] private float rotateMax;

    //private:

    private float rotationValue;

    // Start is called before the first frame update
    void Start()
    {
        rotationValue = Random.Range(rotateMin, rotateMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationValue) * Time.deltaTime);
    }
}
