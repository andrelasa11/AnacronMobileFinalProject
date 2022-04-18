using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private PlayerController player;

    [HideInInspector] public PlayerController PlayerA { get { return player; } }

    //private
    private int playerGold;

    private void Awake()
    {
        Instance = this;
    }

    public void OnDie(GameObject deadObject, int gold = 0)
    {
        playerGold += gold;
        Debug.LogFormat("GameController: {0} has died! Adding gold {1}, total: {2}", deadObject.name, gold, playerGold);
    }

    public void OnPickupPickedUp(PickupController pickup)
    {        
        player.UnlockSpecial(pickup.config);
    }

    public void OnPlayerDie()
    {
        Debug.Log("***** PLAYER DIED!! *****");
    }
}
