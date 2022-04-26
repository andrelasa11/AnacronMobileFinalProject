using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("Player: ")]
    public float fireRate;
    public float maxHealth;
    public int numberOfCannons;
    public float speed;

    [Header("GameController: ")]
    public int gold;
    public int gameLevel;

    [Header("DoDamage: ")]
    public float playerBulletDamage;

    [Header("Upgrade Levels: ")]
    public int shootDamageLevel = 1;
    public int fireRateLevel = 1;
    public int cannonsLevel = 1;
    public int speedLevel = 1;
    public int maxHealthLevel = 1;
    //private int laserLevel = 1;

    public PlayerData (GameManager gmConfig)
    {
        fireRate = gmConfig.fireRate;
        maxHealth = gmConfig.maxHealth;
        numberOfCannons = gmConfig.numberOfCannons;
        speed = gmConfig.speed;

        gold = gmConfig.gold;
        gameLevel = gmConfig.gameLevel;

        playerBulletDamage = gmConfig.playerBulletDamage;

        shootDamageLevel = gmConfig.shootDamageLevel;
        fireRateLevel = gmConfig.fireRateLevel;
        cannonsLevel = gmConfig.cannonsLevel;
        speedLevel = gmConfig.speedLevel;
        maxHealthLevel = gmConfig.maxHealthLevel;
        //laserLevel = gm.Config.laserLevel;
    }
}
