using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] private StateCheck mainPartOfBoss;
    [SerializeField] private UnityEvent onMainPartWasDestroyedActions;


    public void InvokeDestruction()
    {
        if(mainPartOfBoss != null && mainPartOfBoss.isDead)
        {
            onMainPartWasDestroyedActions.Invoke();
        }
    }
        
    
}
