using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyConfig", menuName = "Enemies/Enemy Config", order = 0)]
public class EnemyConfig : ScriptableObject
{
    public float enemySpeed;
    public Sprite sprite;
    public bool isShooter;
    public float shootInitialWaitTime;
    public float shootCadence;
}
