using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class OnTriggerEnterDo : MonoBehaviour
{
    [SerializeField] private UnityEvent unconditionedActions;
    [SerializeField] private UnityEvent conditionedActions;
    [SerializeField] private List<string> tagsToIgnore;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pickup") || collision.CompareTag("Vortex"))
        {
            return;
        }

        unconditionedActions.Invoke(); // invocando as a��es incondicionadas, pois elas n�o s�o filtradas

        foreach (string ignoredTag in tagsToIgnore)
        {
            if (collision.CompareTag(ignoredTag))
            {
                return;
            }
        }

        conditionedActions.Invoke();

    }


}
