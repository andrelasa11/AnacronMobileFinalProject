using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoDamage : MonoBehaviour
{
    public float damage;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController characterLife = collision.GetComponent<HealthController>();

        if (characterLife != null)
        {
            characterLife.ReceiveDamage(damage);
        }

    }
}
