using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    
    public float maxHealth;
    public float healthPoints;

    public HealthBar healthBar;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private UnityEvent onZeroHealthPointsActions;

    void Start() 
    {
        if (gmConfig != null)
        {
            maxHealth = gmConfig.maxHealth;
        }
        
        healthPoints = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void ReceiveDamage(float damagePoints)
    {
        healthPoints -= damagePoints;
        
        if(healthBar != null)
        {
            healthBar.SetHealth(healthPoints);
        }        

        if(healthPoints <=0)
        {
            OnZeroHealthPoints();
        }
    }

    public void SetHealth(float value)
    {
        healthPoints = value;
    }

    public void Healing (float healingPoints)
    {
        float provisionalHealth = healthPoints + healingPoints;

        if(provisionalHealth > maxHealth)
        {
            provisionalHealth = maxHealth;
        }

        healthPoints = provisionalHealth;

        if(healthBar != null)
        {
            healthBar.SetHealth(healthPoints);
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
