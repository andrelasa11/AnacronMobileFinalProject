using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private PlayerController player;

    public delegate void GoldChanged(int updatedGold);
    public event GoldChanged OnGoldChanged;

    [HideInInspector] public PlayerController PlayerA { get { return player; } }

    public GameManagerConfig gmanagerConfig;

    public int _playerGold;

    public int PlayerGold
    {
        get { return _playerGold; }
        private set 
        { 
            _playerGold = value;
            if(OnGoldChanged != null)
            {
                OnGoldChanged.Invoke(_playerGold);
                gmanagerConfig.gold = _playerGold;
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        _playerGold = gmanagerConfig.gold;
    }

    public void OnDie(GameObject deadObject, int gold = 0)
    {
        PlayerGold += gold;
        Debug.LogFormat("GameController: {0} has died! Adding gold {1}, total: {2}", deadObject.name, gold, PlayerGold);
    }

    public void OnPickupPickedUp(PickupController pickup)
    {        
        player.UnlockSpecial(pickup.config);
    }

    public void OnPlayerDie()
    {
        Debug.Log("***** PLAYER DIED!! *****");
        SceneManager.LoadScene("GameOver");        
    }
}
