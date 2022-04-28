using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New GManagerConfig", menuName = "GameManager/Game Config", order = 0)]
public class GameManagerConfig : ScriptableObject
{
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
       

}
