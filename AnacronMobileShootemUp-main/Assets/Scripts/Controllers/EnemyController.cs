using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[HideInInspector]
    public EnemyConfig config;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MultipleInstantiator pickupMultipleInstantiator;
    
    //private
    private Mover mover;
    private Shooter[] shooters;
    private HealthController healthController;
    
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        healthController = GetComponent<HealthController>();
    
        if (mover != null)
        {
            mover.speed = config.enemySpeed;
        }

        if (config.sprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = config.sprite;
        }

        if (healthController != null)
        {
            healthController.healthPoints = config.healthPoints;
        }

        shooters = GetComponentsInChildren<Shooter>();
        if (shooters != null && shooters.Length > 0)
        {
            foreach (var shooter in shooters)
            {
                StartCoroutine(ShootForever(shooter));
            }
            
        }             

    }

    public void OnDie()
    {
        if (config != null && pickupMultipleInstantiator != null && config.ShouldThrowPickup())
        {
            if (pickupMultipleInstantiator.InstantiatorsCount > 1)
            {
                for (int i = 0; i < pickupMultipleInstantiator.InstantiatorsCount; i++)
                {
                    if(Dice.IsChanceSuccess(config.pickupChance))
                    {
                        pickupMultipleInstantiator.InstantiateByIndex(i);
                    }
                }
            }
            else
            {
                pickupMultipleInstantiator.InstantiateInSequence();
            }
        }

        StopAllCoroutines();
        Debug.Log("Hey, I'm dead!");
        GameController.Instance.OnDie(gameObject, config.gold);
    }


    private IEnumerator ShootForever(Shooter shooter)
    {
        yield return new WaitForSeconds(shooter.ShootingConfig.shootInitialWaitTime);

        while (true)
        {
            shooter.DoShoot();

            yield return new WaitForSeconds(shooter.ShootingConfig.shootCadence);
        }
    }
        
}
