using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float damage;
    public GameManagerConfig config;

    private void Start()
    {
        if(config != null)
        {
            damage = config.playerBulletDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController characterLife = collision.GetComponent<HealthController>();

        if (characterLife != null)
        {
            characterLife.ReceiveDamage(damage);
        }


    }

    public void IncreaseDamage(float value)
    {
        if (value > 0)
        {
            damage += value;
        }
    }
}
