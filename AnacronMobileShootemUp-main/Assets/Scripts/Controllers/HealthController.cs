using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public float healthPoints;
    [SerializeField] private UnityEvent onZeroHealthPointsActions;

    public void ReceiveDamage(float damagePoints)
    {
        healthPoints -= damagePoints;
        if(healthPoints <=0)
        {
            OnZeroHealthPoints();
        }
    }

    public void OnZeroHealthPoints()
    {
        if(onZeroHealthPointsActions != null)
        {
            Debug.LogFormat("Activating!");
            onZeroHealthPointsActions.Invoke();
        }
    }
}
