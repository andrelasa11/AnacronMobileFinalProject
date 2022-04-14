using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyConfig", menuName = "Enemies/Enemy Config", order = 0)]
public class EnemyConfig : ScriptableObject
{
    [Header("Attributes")]
    public float enemySpeed;
    public float healthPoints;

    [Header("Others")]
    public Sprite sprite;
    public int gold;        
}
