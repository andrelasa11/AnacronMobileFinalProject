using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerConfig gmConfig;

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

 
    public void SavePlayer()
    {
        gmConfig.gameLevel++;
        
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

        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        fireRate = data.fireRate;
        maxHealth = data.maxHealth;
        numberOfCannons = data.numberOfCannons;
        speed = data.speed;

        gold = data.gold;
        gameLevel = data.gameLevel;

        playerBulletDamage = data.playerBulletDamage;

        shootDamageLevel = data.shootDamageLevel;
        fireRateLevel = data.fireRateLevel;
        cannonsLevel = data.cannonsLevel;
        speedLevel = data.speedLevel;
        maxHealthLevel = data.maxHealthLevel;
        //laserLevel = data.laserLevel;

        gmConfig.fireRate = data.fireRate;
        gmConfig.maxHealth = data.maxHealth;
        gmConfig.numberOfCannons = data.numberOfCannons;
        gmConfig.speed = data.speed;

        gmConfig.gold = data.gold;
        gmConfig.gameLevel = data.gameLevel;

        gmConfig.playerBulletDamage = data.playerBulletDamage;

        gmConfig.shootDamageLevel = data.shootDamageLevel;
        gmConfig.fireRateLevel = data.fireRateLevel;
        gmConfig.cannonsLevel = data.cannonsLevel;
        gmConfig.speedLevel = data.speedLevel;
        gmConfig.maxHealthLevel = data.maxHealthLevel;

        SceneManager.LoadScene(gameLevel);

    }
}
