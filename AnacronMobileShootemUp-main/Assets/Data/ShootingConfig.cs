using UnityEngine;

[CreateAssetMenu(fileName = "New ShootingConfig", menuName = "Shooting/Shooting Config", order = 0)]
public class ShootingConfig : ScriptableObject
{
    [Header("Shotters")]
    public float shootInitialWaitTime;
    public float shootCadence;
    public float damage;

}
