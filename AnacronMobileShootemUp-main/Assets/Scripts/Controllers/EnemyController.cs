using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public EnemyConfig config;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //private
    private Mover mover;
    private Shooter[] shooters;
    
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        if (mover != null)
        {
            mover.speed = config.enemySpeed;
        }

        if (config.sprite != null)
        {
            spriteRenderer.sprite = config.sprite;
        }

        if (config.isShooter)
        {
            shooters = GetComponentsInChildren<Shooter>();
            if (shooters != null && shooters.Length > 0)
            {
                StartCoroutine(ShootForever());
            }
        }               

    }

    public void OnDie()
    {
        Debug.Log("Hey, I'm dead!");
        GameController.Instance.OnDie(gameObject, config.score);
    }


    private IEnumerator ShootForever()
    {
        yield return new WaitForSeconds(config.shootInitialWaitTime);

        while (true)
        {
            foreach (var shooter in shooters)
            {
                shooter.DoShoot();
            }

            yield return new WaitForSeconds(config.shootCadence);
        }
    }
        
}
