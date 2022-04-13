using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class OnEnemyTriggerEnterDo : MonoBehaviour
{
    [SerializeField] private UnityEvent unconditionedActions;
    [SerializeField] private UnityEvent conditionedActions;
    [SerializeField] private List<string> tagsToIgnore;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        unconditionedActions.Invoke(); // invocando as ações incondicionadas, pois elas não são filtradas

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
