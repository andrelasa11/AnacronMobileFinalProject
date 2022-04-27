using System.Collections;
using UnityEngine;

public class EvasiveMover : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    private Vector3 direction;

    private void Start()
    {
        StartCoroutine(EvasiveManuever());
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private IEnumerator EvasiveManuever ()
    {
        
        while(true)
        {
            direction = new Vector3(-1, 1, 0);

            yield return new WaitForSeconds(waitTime);

            direction = new Vector3(1, 1, 0);

            yield return new WaitForSeconds(waitTime);
        }           
        
        
    }

}
