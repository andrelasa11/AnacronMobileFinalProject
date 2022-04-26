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
    [Range(0, 1)] public float pickupChance;

    public bool ShouldThrowPickup()
    {
        return Dice.IsChanceSuccess(pickupChance);
    }
}
