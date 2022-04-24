using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{    

    [Header("Upgrades Dependencies")]
    public UGShootDamage shootDamage;
    public UGFireRate fireRate;
    public UGCannons cannons;
    public UGSpeed speed;
    public UGMaxHealth maxHealth;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private Text goldText;
    
    private void Awake()
    {
        goldText.text = " " + gmConfig.gold;
    }

    public void IncreaseShootDamage()
    {
        if(gmConfig.gold >= shootDamage.price && gmConfig.shootDamageLevel < 5)
        {
            gmConfig.gold -= shootDamage.price;

            gmConfig.shootDamageLevel++;

            shootDamage.UpGradeShootDamage();

            goldText.text = " " + gmConfig.gold;
        }
    }

    public void IncreaseFireRate()
    {
        if (gmConfig.gold >= fireRate.price && gmConfig.fireRateLevel < 5)
        {
            gmConfig.gold -= fireRate.price;

            gmConfig.fireRateLevel++;

            fireRate.UpGradeFireRate();

            goldText.text = " " + gmConfig.gold;
        }
    }

    public void IncreaseCannons()
    {
        if (gmConfig.gold >= cannons.price && gmConfig.cannonsLevel < 5)
        {
            gmConfig.gold -= cannons.price;

            gmConfig.cannonsLevel++;

            cannons.UpGradeCannons();

            goldText.text = " " + gmConfig.gold;
        }
    }

    public void IncreaseSpeed()
    {
        if (gmConfig.gold >= speed.price && gmConfig.speedLevel < 5)
        {
            gmConfig.gold -= speed.price;

            gmConfig.speedLevel++;

            speed.UpGradeSpeed();

            goldText.text = " " + gmConfig.gold;
        }
    }

    public void IncreaseMaxHealth()
    {
        if (gmConfig.gold >= maxHealth.price && gmConfig.maxHealthLevel < 5)
        {
            gmConfig.gold -= maxHealth.price;

            gmConfig.maxHealthLevel++;

            maxHealth.UpGradeMaxHealth();

            goldText.text = " " + gmConfig.gold;
        }
    }

}
