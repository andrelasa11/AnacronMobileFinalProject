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
    public int maxLaserPoints;

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
    public int laserLevel = 1;

 
    public void SavePlayer()
    {
        PlayerController.Instance.DisableOrEnableIsFiring();

        gmConfig.gameLevel++;
        
        fireRate = gmConfig.fireRate;
        maxHealth = gmConfig.maxHealth;
        numberOfCannons = gmConfig.numberOfCannons;
        speed = gmConfig.speed;
        maxLaserPoints = gmConfig.maxLaserPoints;

        gold = gmConfig.gold;
        gameLevel = gmConfig.gameLevel;

        playerBulletDamage = gmConfig.playerBulletDamage;

        shootDamageLevel = gmConfig.shootDamageLevel;
        fireRateLevel = gmConfig.fireRateLevel;
        cannonsLevel = gmConfig.cannonsLevel;
        speedLevel = gmConfig.speedLevel;
        maxHealthLevel = gmConfig.maxHealthLevel;
        laserLevel = gmConfig.laserLevel;

        SaveSystem.SavePlayer(this);
    }

    public void SavePlayerOnUpgradeMenu()
    {
        fireRate = gmConfig.fireRate;
        maxHealth = gmConfig.maxHealth;
        numberOfCannons = gmConfig.numberOfCannons;
        speed = gmConfig.speed;
        maxLaserPoints = gmConfig.maxLaserPoints;

        gold = gmConfig.gold;
        gameLevel = gmConfig.gameLevel;

        playerBulletDamage = gmConfig.playerBulletDamage;

        shootDamageLevel = gmConfig.shootDamageLevel;
        fireRateLevel = gmConfig.fireRateLevel;
        cannonsLevel = gmConfig.cannonsLevel;
        speedLevel = gmConfig.speedLevel;
        maxHealthLevel = gmConfig.maxHealthLevel;
        laserLevel = gmConfig.laserLevel;

        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        fireRate = data.fireRate;
        maxHealth = data.maxHealth;
        numberOfCannons = data.numberOfCannons;
        speed = data.speed;
        maxLaserPoints = data.maxLaserPoints;

        gold = data.gold;
        gameLevel = data.gameLevel;

        playerBulletDamage = data.playerBulletDamage;

        shootDamageLevel = data.shootDamageLevel;
        fireRateLevel = data.fireRateLevel;
        cannonsLevel = data.cannonsLevel;
        speedLevel = data.speedLevel;
        maxHealthLevel = data.maxHealthLevel;
        laserLevel = data.laserLevel;

        gmConfig.fireRate = data.fireRate;
        gmConfig.maxHealth = data.maxHealth;
        gmConfig.numberOfCannons = data.numberOfCannons;
        gmConfig.speed = data.speed;
        gmConfig.maxLaserPoints = data.maxLaserPoints;

        gmConfig.gold = data.gold;
        gmConfig.gameLevel = data.gameLevel;

        gmConfig.playerBulletDamage = data.playerBulletDamage;

        gmConfig.shootDamageLevel = data.shootDamageLevel;
        gmConfig.fireRateLevel = data.fireRateLevel;
        gmConfig.cannonsLevel = data.cannonsLevel;
        gmConfig.speedLevel = data.speedLevel;
        gmConfig.maxHealthLevel = data.maxHealthLevel;
        gmConfig.laserLevel = data.laserLevel;

        SceneManager.LoadScene(gameLevel);

    }

    public void ResetValue()
    {
        gmConfig.fireRate = 0.6f;
        gmConfig.maxHealth = 10;
        gmConfig.numberOfCannons = 1;
        gmConfig.speed = 3;
        gmConfig.maxLaserPoints = 5;

        gmConfig.gold = 0;
        gmConfig.gameLevel = 1;

        gmConfig.playerBulletDamage = 1;

        gmConfig.shootDamageLevel = 1;
        gmConfig.fireRateLevel = 1;
        gmConfig.cannonsLevel = 1;
        gmConfig.speedLevel = 1;
        gmConfig.maxHealthLevel = 1;
        gmConfig.laserLevel = 1;
    }
}
