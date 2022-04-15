using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private ShootingConfig config;
    public ShootingConfig ShootingConfig { get { return config; } }

    public bool IsEnabled = true;

    public void DoShoot()
    {
        if (IsEnabled && shootOrigin != null)
        {
            Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
        }        
    }

    public void EnableShooter(bool shouldEnable)
    {
        IsEnabled = shouldEnable;
    }
}
